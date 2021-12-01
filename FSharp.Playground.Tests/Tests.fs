namespace FSharp.Playground.Workshop

module Tests =

    open Xunit
    open FSharp.Playground.Workshop.Types
    open FSharp.Playground.Workshop.Functions

    [<Fact>]
    let ``Customer creation`` () =
        let customer = { Id = 1; IsVip = false; Credit = 0M }
        Assert.Equal(1, customer.Id)
        Assert.Equal(false, customer.IsVip)

    [<Fact>]
    let ``getPurchases customer with even id`` () =
        let customer = { Id = 1; IsVip = false; Credit = 0M }
        let (c, value) = getPurchases customer
        Assert.Equal(80M, value)

    [<Fact>]
    let ``getPurchases customer with odd id`` () =
        let customer = { Id = 4; IsVip = false; Credit = 0M }
        let (c, value) = getPurchases customer
        Assert.Equal(120M, value)

    [<Fact>]
    let ``tryPromoteToVIP customer with purschase under 100 is not promoted`` () =
        let customer = { Id = 1; IsVip = false; Credit = 10M }
        let functionChain = getPurchases >> tryPromoteToVip
        let result1 = functionChain customer
        Assert.False(result1.IsVip)

        let functionPipeline c = 
            c
            |> getPurchases
            |> tryPromoteToVip
        let result2 = functionPipeline customer
        Assert.False(result2.IsVip)

    [<Fact>]
    let ``increase customer is vip`` () =
        let customer = { Id = 1; IsVip = true; Credit = 100M }
        let c = increaseCreditUsingVip customer
        Assert.Equal(200M, c.Credit)

    [<Fact>]
    let ``increase customer is not vip`` () =
        let customer = { Id = 1; IsVip = false; Credit = 100M }
        let c = increaseCreditUsingVip customer
        Assert.Equal(150M, c.Credit)