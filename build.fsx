// Include FAKE lib
#r "packages/FAKE/tools/FakeLib.dll"
open Fake
open Fake.FscHelper

// Directories
let buildDir = "./build/"
let testDir  = "./test/"
let deployDir= "./deploy/"

// Files
let libInputFiles = [
    "src/Fi/input.fs";
    "src/Fi/keys.fs"
]
let libAppFiles = [
    "src/Fi/main.fs"
]

// Targets
Target "Clean" (fun _ ->
    CleanDir buildDir
    CleanDir testDir
    CleanDir deployDir
)

Target "Libs" (fun _ ->
    libInputFiles
    |> Fsc (fun p -> { p with FscTarget = Library })
)

Target "Main" (fun _ ->
    libAppFiles
    |> Fsc (fun p -> { p with References = ["Libs"] })
)


// Dependencies
"Clean"
    ==> "Libs"
    ==> "Main"



// start build
RunTargetOrDefault "Main"
