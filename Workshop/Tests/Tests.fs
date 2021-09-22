namespace FSharp.Playground.Workshop

open Xunit
open Types

module Tests =

    [<Fact>]
    let CreateCustomer() = 
        let c = { Id = 1; IsVip = true; Credit = 100M }
        Assert.IsType<Customer> c