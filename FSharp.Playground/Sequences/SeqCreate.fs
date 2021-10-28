namespace FSharp.Playground

module SeqCreate =

    let integers 
        = Seq.init 1000 (fun i -> i + 1)

    let anotherIntegers 
        = seq {1..5..50}