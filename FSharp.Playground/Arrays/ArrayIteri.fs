namespace FSharp.Playground

module ArrayIteri =

    let Iter() = 

        let input = [| 10; 14; 4; 3; 98; 16; 67; 33 |]

        input 
        |> Array.sort
        |> Array.iteri (fun i number -> printf "%i. %i\n" i number)