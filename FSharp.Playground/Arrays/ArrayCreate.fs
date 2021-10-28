namespace FSharp.Playground

module ArrayCreate =

    let sample = 
        [|10..20|]

    let evenNumbers = [|for i in 10..100 do if i%2 = 0 then yield i|]

    let files = 
        System.IO.Directory.EnumerateFiles @"C:\Users\Michal Kohut\source\repos"
        |> Array.ofSeq

    let lastDays (year:int) =
        Array.init 12 (fun i -> 
            let month = i + 1
            let firstDay = System.DateTime(year, month, 1)
            let lastDay = firstDay.AddDays(float (System.DateTime.DaysInMonth(year, month) - 1))
            lastDay
        )