namespace FSharp.Playground.Workshop

    module Tests =

        open Xunit
        open FSharp.Playground.Workshop.Types

        [<Fact>]
        let ``My test`` () =
            let customer = { Id = 1; IsVip = false; Credit = 0M }
            Assert.Equal(1, customer.Id)
