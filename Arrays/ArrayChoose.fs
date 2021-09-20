namespace FSharp.Playground

module ArrayChoose =

    open System.Net

    let sites = 
        [|
            "http://www.google.com"
            "http://www.pluralsight.com"
            "http://notexisting.sk"
        |]

    let GetRequests (urls : string []) =
        use wc = new WebClient()
        urls
        |> Array.choose (fun url -> 
            try 
                wc.DownloadString url |> Some
            with 
                _ -> None)
        |> Array.map (fun content -> sprintf "%s" (content.Substring(0, 100)))
        //|> Array.iteri (fun i url -> printf "%i. %s" i (url.Substring(0, 10))) 
