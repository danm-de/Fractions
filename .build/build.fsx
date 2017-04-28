// include Fake lib
#r "../packages/build/FAKE/tools/FakeLib.dll"
open Fake
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

  let buildMode = getBuildParamOrDefault "buildMode" buildConfig
  let setParams defaults =
        { defaults with
            Verbosity = Some(Quiet)
            RestorePackagesFlag = true
            Targets = ["Build"]
            Properties =
                [
                    "Optimize", "True"
                    "DebugSymbols", "True"
                    "Configuration", buildMode
                ]
         }
  build setParams solutionFile
      |> DoNothing

  //MSBuild outDir "Build" ["Configuration", buildConfig; "Platform", "Any CPU"] [solutionFile] |> Log "MSBuild"

// Targets
Target "Clean" (fun _ ->
    traceHeader "Prepare build directory.."
    CleanDirs [dirBuildTest; dirBuildOutput]
    CleanSolution fileSolution buildConfig dirBuildBin
)

Target "BuildApp" (fun _ ->
    BuildSolution fileSolution buildConfig dirBuildBin
)

Target "Test" (fun _ ->
    !! (dirProjectRoot @@ (sprintf "**/bin/%s/*.Tests.dll" buildConfig))
      |> NUnit (fun p ->
          {p with
             DisableShadowCopy = true;
             OutputFile = dirBuildOutput + "/TestResult.xml"
          })
)

Target "NuGet" (fun _ ->
    Paket.Pack(fun p ->
        {p with
           OutputPath = dirBuildNuget 
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

// Dependencies
"Clean"
  ==> "BuildApp"
  ==> "Test"
  ==> "Default"

"Test"
  ==> "NuGet"

"NuGet"
  ==> "NuGetPush"

// start build
RunTargetOrDefault "Default"