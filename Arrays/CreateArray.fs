module Arrays

let sample = [|10..20|]

let evenNumbers = [|for i in 10..100 do if i%2 = 0 then yield i|]

let files = 
    System.IO.Directory.EnumerateFiles @"C:\Users\Michal Kohut\source\repos"
    |> Array.ofSeq

open System

let lastDays (year:int) =
    Array.init 12 (fun i -> 
        let month = i + 1
        let firstDay = DateTime(year, month, 1)
        let lastDay = firstDay.AddDays(float (DateTime.DaysInMonth(year, month) - 1))
        lastDay
    )
