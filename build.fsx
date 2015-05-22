// Include FAKE lib
#r "packages/FAKE/tools/FakeLib.dll"
open Fake
open Fake.FscHelper

// Directories
let buildDir = "./build/"
let testDir  = "./test/"
let deployDir= "./deploy/"
let name = "fi.exe"

// Files
let libInputFiles = [
    "src/Fi/input.fs";
    "src/Fi/keys.fs";
]
let libAppFiles = [
    "src/Fi/main.fsx";
]
let projectReferences = [
    "packages/Eto.Forms/lib/net45/Eto.dll";
]

let frameworkReferences = [
    "System.Runtime"
]

// Targets
Target "Clean" (fun _ ->
    CleanDir buildDir
    CleanDir testDir
    CleanDir deployDir
)

Target "Libs" (fun _ ->
    libInputFiles |> Fsc (fun p -> { p with FscTarget = Library })
)

Target "Main" (fun _ ->
    projectReferences |> List.iter(CopyFile buildDir)

    libAppFiles |> Fsc (fun p -> { p with References = projectReferences @ frameworkReferences; Output = buildDir @@ name })
)


// Dependencies
"Clean"
    //==> "Libs"
    ==> "Main"



// start build
RunTargetOrDefault "Main"
