// include Fake lib
#r "../packages/build/FAKE/tools/FakeLib.dll"
open Fake
open Fake.Testing.NUnit3
open System

let RequiredEnvironVar name =
  match environVarOrNone name with
    | Some(envVar) -> envVar
    | None -> sprintf "The environment variable '%s' has no value" name |> failwith

// build settings
let buildConfig = environVarOrDefault "build_configuration" "Release"
let fileSolution = RequiredEnvironVar "file_solution"
let dirProjectRoot = System.IO.Path.GetDirectoryName (FullName fileSolution)
let dirBuildOutput = dirProjectRoot @@ "_build.output"
let dirBuildBin = ""
let dirBuildTest = dirBuildOutput @@ "tests"
let dirBuildNuget = dirBuildOutput @@ "nuget"

let PrintVariables() =
  traceHeader "Build settings:"
  trace String.Empty
  trace (sprintf "%s -> %s" "dirProjectRoot" dirProjectRoot)
  trace (sprintf "%s -> %s" "dirBuildOutput" dirBuildOutput)
  trace (sprintf "%s -> %s" "dirBuildBin" dirBuildBin)
  trace (sprintf "%s -> %s" "dirBuildTest" dirBuildTest)
  trace (sprintf "%s -> %s" "dirBuildNuget" dirBuildNuget)
  trace String.Empty
  trace (sprintf "%s -> %s" "fileSolution" fileSolution)
  trace String.Empty
  trace (sprintf "%s -> %s" "buildConfig" buildConfig)
  trace String.Empty

PrintVariables()

let CleanSolution solutionFile buildConfig outputPath =
  sprintf "Cleanup %s .." solutionFile |> traceHeader
  let outDir = if isNotNullOrEmpty outputPath then outputPath else ""
  MSBuild outDir "Clean" ["Configuration", buildConfig; "Platform", "Any CPU"] [solutionFile] |> Log "MSBuild"

let BuildSolution solutionFile buildConfig outputPath =
  sprintf "Building %s with configuration %s .." solutionFile buildConfig |> traceHeader
  let outDir = if isNotNullOrEmpty outputPath then outputPath else ""
  let targets = [
    "Restore" 
    "Build"
  ]
  targets
    |> Seq.iter (fun target ->
       MSBuild outDir target ["Configuration", buildConfig; "Platform", "Any CPU"] [solutionFile] |> Log "MSBuild"
    )  

// Targets
Target "Clean" (fun _ ->
  traceHeader "Prepare build directory.."
  CleanDirs [dirBuildTest; dirBuildOutput]
  CleanSolution fileSolution buildConfig dirBuildBin
)

Target "Build" (fun _ ->
  BuildSolution fileSolution buildConfig dirBuildBin
)

Target "CopyNuGetToOutput" (fun _ ->
  !! ("src" @@ "**" @@ "bin" @@ buildConfig @@ "*.nupkg")
    |> Copy dirBuildNuget
)

Target "Test" (fun _ ->
  ensureDirectory dirBuildTest
  !! (dirProjectRoot @@ (sprintf "**/bin/%s/*.Tests.dll" buildConfig))
    |> NUnit3 (fun p ->
      {p with
         ShadowCopy  = false;
         WorkingDir = dirBuildTest;
         OutputDir = dirBuildTest @@ "TestResult.txt";
      })
)

Target "NuGetPush" (fun _ ->
  Paket.Push(fun p -> 
    {p with
       WorkingDir = dirBuildNuget
       DegreeOfParallelism = 1
    })
)

Target "Default" (fun _ ->
  trace "PC/SC wrapper classes for .NET"
)

Target "" ignore

// Dependencies
"Clean"
  ==> "Build"
  ==> "CopyNuGetToOutput"
  ==> "Test"
  ==> "Default"

"CopyNuGetToOutput"
  ==> "NuGetPush"

// start build
RunTargetOrDefault "Default"