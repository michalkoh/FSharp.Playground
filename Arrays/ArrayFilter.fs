namespace FSharp.Playground

module ArrayFilter =

    let IsExe (filename : string) =
        filename.EndsWith("EXE")

    let files = 
        System.IO.Directory.EnumerateFiles (@"C:\Windows10Upgrade")
        |> Array.ofSeq
        |> Array.filter IsExe

    let files2 = 
        System.IO.Directory.EnumerateFiles (@"C:\Windows10Upgrade")
        |> Array.ofSeq
        |> Array.filter (fun i -> i.EndsWith "EXE")
