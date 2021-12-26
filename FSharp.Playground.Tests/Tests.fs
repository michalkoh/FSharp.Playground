namespace FSharp.Playground.Workshop

module Tests =

    open Xunit
    open FSharp.Playground.Workshop.Types
    open FSharp.Playground.Workshop.Functions
    open System

    let createCustomer = 
        { Id = 1; IsVip = false; Credit = 100M<EUR>; PersonalDetails = Some { FirstName = "Matej"; Lastname = "Kohut"; DateOfBirth = DateTime(2012, 2, 24) }; Notifications = NoNotifications }

    [<Fact>]
    let ``Customer creation`` () =
        let customer = { createCustomer with Credit = 0M<EUR> }
        Assert.Equal(1, customer.Id)
        Assert.Equal(false, customer.IsVip)

    [<Fact>]
    let ``getPurchases customer with even id`` () =
        let customer = createCustomer
        let (c, value) = getPurchases customer
        Assert.Equal(80M<EUR>, value)

    [<Fact>]
    let ``getPurchases customer with odd id`` () =
        let customer = { createCustomer with Id = 4 }
        let (c, value) = getPurchases customer
        Assert.Equal(120M<EUR>, value)

    [<Fact>]
    let ``tryPromoteToVIP customer with purchase under 100 is not promoted`` () =
        let customer = createCustomer
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
    let ``tryPromoteToVIP customer with purchase above 100 is promoted`` () =
        let customer = { createCustomer with Id = 2 }
        let result = customer |> getPurchases |> tryPromoteToVip
        Assert.True(result.IsVip)

    [<Fact>]
    let ``increase customer is vip`` () =
        let customer = { createCustomer with IsVip = true }
        let c = increaseCreditUsingVip customer
        Assert.Equal(200M<EUR>, c.Credit)

    [<Fact>]
    let ``increase customer is not vip`` () =
        let customer = createCustomer
        let c = increaseCreditUsingVip customer
        Assert.Equal(150M<EUR>, c.Credit)

    [<Fact>]
    let ``isAdult customer is adult`` () =
        let customer = { createCustomer with PersonalDetails = Some { FirstName = "Matej"; Lastname = "Kohut"; DateOfBirth = DateTime(1990, 2, 24) } }
        let adult = isAdult customer
        Assert.True(adult)

    [<Fact>]
    let ``isAdult customer is not adult`` () =
        let customer = createCustomer
        let adult = isAdult customer
        Assert.False(adult)

    [<Fact>]
    let ``upgradeCustomer who is vip increased by 100`` () =
        let customer = { createCustomer with Id = 2 }
        let upgradedCustomer = upgradeCustomer customer
        Assert.Equal(200M<EUR>, upgradedCustomer.Credit)
