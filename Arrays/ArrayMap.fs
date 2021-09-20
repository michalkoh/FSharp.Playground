namespace FSharp.Playground

module ArrayMap =
    open System

    let MakeFirstUpper (input : string) =
        if String.IsNullOrEmpty input then
            input
        else
            input.[0].ToString().ToUpper() + input.[1..] 

    let Colors = 
        [|"blue"; "yellow"; "white"; "black"|]

    let Upperize = 
        Colors
        |> Array.map (MakeFirstUpper)