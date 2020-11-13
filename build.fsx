#r "paket:
nuget Fake.Core.Target
nuget Fake.DotNet.Cli
nuget Fake.IO.FileSystem
nuget Fake.BuildServer.AppVeyor //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.DotNet
open Fake.DotNet.NuGet
open Fake.IO
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators
open Fake.BuildServer

BuildServer.install [
    AppVeyor.Installer
]

Target.create "Clean" (fun _ ->
    !! "src/**/bin"
    ++ "src/**/obj"
    ++ "Tests/**/bin"
    ++ "Tests/**/obj"
        |> Shell.cleanDirs
)

Target.create "Build" (fun _ ->
    let runBuild =
      DotNet.build (fun p ->
        { p with
            Configuration = DotNet.BuildConfiguration.Release
        })

    !! "src/**/*.*proj"
    ++ "Tests/**/*.*proj"
        |> Seq.iter runBuild
)

Target.create "Test" (fun _ ->
    let runTest =
      DotNet.test (fun p ->
        { p with
            ResultsDirectory = Some "TestResults"
            Logger = Some "trx"
            Configuration = DotNet.BuildConfiguration.Release
        })

    !! "Tests/**/*.*proj"
        |> Seq.iter runTest

    // publish unit test results
    !! "TestResults/*.trx"
        |> Seq.iter (Trace.publish (ImportData.Mstest))
)

Target.create "NuGetPush" (fun _ ->
    let setNugetPushParams (defaults:NuGet.NuGetPushParams) =
        { defaults with
            Source = Some "https://api.nuget.org/v3/index.json"
        }

    let setParams (defaults:DotNet.NuGetPushOptions) =
        { defaults with
            PushParams = setNugetPushParams defaults.PushParams
        }

    !! "src/**/bin/Release/*.nupkg"
        |> Seq.iter (fun file -> DotNet.nugetPush setParams file)
)

Target.create "All" ignore

"Clean"
    ==> "Build"
    ==> "Test"
    ==> "All"

"Build"
    ==> "NuGetPush"

Target.runOrDefault "All"
