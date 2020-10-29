namespace FSharp.Playground

module Mix =

    let applyFunction (f: int -> int -> int)  x y = 
        f x y

    let mul x y =
        x * y

    let z = 
        applyFunction mul 5 6