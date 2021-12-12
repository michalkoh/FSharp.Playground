namespace FSharp.Playground.Workshop

module Tests =

    open Xunit
    open FSharp.Playground.Workshop.Types
    open FSharp.Playground.Workshop.Functions
    open System

    [<Fact>]
    let ``Customer creation`` () =
        let customer = { Id = 1; IsVip = false; Credit = 0M<EUR>; PersonalDetails = { FirstName = "Michal"; Lastname = "Kohut"; DateOfBirth = DateTime(1984, 2, 24) }; Notifications = NoNotifications }
        Assert.Equal(1, customer.Id)
        Assert.Equal(false, customer.IsVip)

    [<Fact>]
    let ``getPurchases customer with even id`` () =
        let customer = { Id = 1; IsVip = false; Credit = 0M<EUR>; PersonalDetails = { FirstName = "Michal"; Lastname = "Kohut"; DateOfBirth = DateTime(1984, 2, 24) }; Notifications = NoNotifications }
        let (c, value) = getPurchases customer
        Assert.Equal(80M<EUR>, value)

    [<Fact>]
    let ``getPurchases customer with odd id`` () =
        let customer = { Id = 4; IsVip = false; Credit = 0M<EUR>; PersonalDetails = { FirstName = "Michal"; Lastname = "Kohut"; DateOfBirth = DateTime(1984, 2, 24) }; Notifications = NoNotifications }
        let (c, value) = getPurchases customer
        Assert.Equal(120M<EUR>, value)

    [<Fact>]
    let ``tryPromoteToVIP customer with purchase under 100 is not promoted`` () =
        let customer = { Id = 1; IsVip = false; Credit = 10M<EUR>; PersonalDetails = { FirstName = "Michal"; Lastname = "Kohut"; DateOfBirth = DateTime(1984, 2, 24) }; Notifications = NoNotifications }
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
        let customer = { Id = 2; IsVip = false; Credit = 10M<EUR>; PersonalDetails = { FirstName = "Michal"; Lastname = "Kohut"; DateOfBirth = DateTime(1984, 2, 24) }; Notifications = NoNotifications }
        let result = customer |> getPurchases |> tryPromoteToVip
        Assert.True(result.IsVip)

    [<Fact>]
    let ``increase customer is vip`` () =
        let customer = { Id = 1; IsVip = true; Credit = 100M<EUR>; PersonalDetails = { FirstName = "Michal"; Lastname = "Kohut"; DateOfBirth = DateTime(1984, 2, 24) }; Notifications = NoNotifications }
        let c = increaseCreditUsingVip customer
        Assert.Equal(200M<EUR>, c.Credit)

    [<Fact>]
    let ``increase customer is not vip`` () =
        let customer = { Id = 1; IsVip = false; Credit = 100M<EUR>; PersonalDetails = { FirstName = "Michal"; Lastname = "Kohut"; DateOfBirth = DateTime(1984, 2, 24) }; Notifications = NoNotifications }
        let c = increaseCreditUsingVip customer
        Assert.Equal(150M<EUR>, c.Credit)