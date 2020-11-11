namespace FSharp.Playground

module ArraySum =

    open System.Net

    let GetTotalLenth() = 
        let requests = 
            [|
                "http://www.google.com"
                "http://www.pluralsight.com"
            |]

        use wc = new WebClient()

        requests
        |> Array.choose (fun url ->
            try 
                wc.DownloadString(url) |> Some
            with 
            | _ -> None)
        |> Array.map (fun content -> content.Length)
        |> Array.sum