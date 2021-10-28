namespace FSharp.Playground

module Mix =

    let applyFunction (f: int -> int -> int)  x y = 
        f x y

    let mul x y =
        x * y

    let z = 
        applyFunction mul 5 6

    // Pattern matching function. 
    type Oddness =
        | IsOdd
        | IsEven

    let getOddness = function
        | x when (x % 2) = 0 -> IsEven
        | _ -> IsOdd 

    // Match expression.
    let getOddness2 x = 
        match x with 
            | x when (x % 2) = 0 -> IsEven
            | _ -> IsOdd
            