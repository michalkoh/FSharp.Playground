open FSharp.Playground.Workshop.Classes

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let x = MyClassWithConstructor(123)
    0 // return an integer exit code
