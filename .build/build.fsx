// include Fake lib
#r "../packages/FAKE/tools/FakeLib.dll"
open Fake
open System

MSBuildDefaults <- { MSBuildDefaults with Verbosity = Some (Quiet) }

let RequiredEnvironVar name =
  match environVarOrNone name with
    | Some(envVar) -> envVar
    | None -> sprintf "The environment variable '%s' has no value" name |> failwith

// build settings
let _build_config = environVarOrDefault "build_configuration" "Release"
let _file_solution = RequiredEnvironVar "file_solution"
let _file_buildlog = RequiredEnvironVar "file_buildlog"

let _dir_project_root = System.IO.Path.GetDirectoryName (FullName _file_solution)
let _dir_build_output = _dir_project_root @@ "_build.output"
let _dir_build_bin = ""
let _dir_build_tests = _dir_build_output @@ "tests"
let _dir_build_nuget = _dir_build_output @@ "nuget"

let PrintVariables() =
  traceHeader "Build settings:"
  trace String.Empty
  trace (sprintf "%s -> %s" "_dir_project_root" _dir_project_root)
  trace (sprintf "%s -> %s" "_dir_build_output" _dir_build_output)
  trace (sprintf "%s -> %s" "_dir_build_bin" _dir_build_bin)
  trace (sprintf "%s -> %s" "_dir_build_tests" _dir_build_tests)
  trace (sprintf "%s -> %s" "_dir_build_nuget" _dir_build_nuget)
  trace String.Empty
  trace (sprintf "%s -> %s" "_file_solution" _file_solution)
  trace (sprintf "%s -> %s" "_file_buildlog" _file_buildlog)
  trace String.Empty
  trace (sprintf "%s -> %s" "_build_config" _build_config)
  trace String.Empty

PrintVariables()

let CleanSolution solutionFile buildConfig outputPath =
  sprintf "Cleanup %s .." solutionFile |> traceHeader
  let outDir = if isNotNullOrEmpty outputPath then outputPath else ""
  MSBuild outDir "Clean" ["Configuration", buildConfig; "Platform", "Any CPU"] [solutionFile] |> Log "MSBuild"

let BuildSolution solutionFile buildConfig outputPath =
  sprintf "Building %s with configuration %s .." solutionFile buildConfig |> traceHeader
  let outDir = if isNotNullOrEmpty outputPath then outputPath else ""
  MSBuild outDir "Build" ["Configuration", buildConfig; "Platform", "Any CPU"] [solutionFile] |> Log "MSBuild"

// Targets
Target "Clean" (fun _ ->
    traceHeader "Prepare build directory.."
    CleanDirs [_dir_build_tests; _dir_build_output]
    CleanSolution _file_solution _build_config _dir_build_bin
)

Target "BuildApp" (fun _ ->
    BuildSolution _file_solution _build_config _dir_build_bin
)

Target "Test" (fun _ ->
    !! (_dir_project_root @@ (sprintf "**/bin/%s/Tests.*.dll" _build_config))
      |> NUnit (fun p ->
          {p with
             DisableShadowCopy = true;
             OutputFile = _dir_build_output + "/TestResult.xml"
          })
)

Target "NuGet" (fun _ ->
    Paket.Pack(fun p ->
        {p with
           OutputPath = _dir_build_nuget 
        })
)

Target "NuGetPush" (fun _ ->
    Paket.Push(fun p -> 
        {p with
           WorkingDir = _dir_build_nuget
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
