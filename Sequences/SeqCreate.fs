namespace FSharp.Playground

module SeqCreate =

    let integers 
        = Seq.init 1000 (fun i -> i + 1)