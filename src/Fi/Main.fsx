#if INTERACTIVE
#r "../../packages/Eto.Forms/lib/net45/Eto.dll"
#r "System.Runtime"
#endif

open System
open System.IO
open Eto.Forms


[<EntryPoint; STAThread>]
let main args =
    use a = new Application()

    0
