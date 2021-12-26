namespace FSharp.Playground.Workshop

module Functions = 

    open FSharp.Playground.Workshop.Types
    open System

    let getPurchases (customer : Customer) = 
        if customer.Id % 2 = 0 
            then (customer, 120M<EUR>)
            else (customer, 80M<EUR>)

    let tryPromoteToVip (customerWithPurchases : Customer * decimal<EUR>) =
        let (customer, amount) = customerWithPurchases
        if (amount > 100M<EUR>)
            then { customer with IsVip = true }
            else customer

    let increase condition customer = 
        if condition customer  
            then { customer with Credit = customer.Credit + 100M<EUR> }
            else { customer with Credit = customer.Credit + 50M<EUR> }

    let increaseCreditUsingVip = increase (fun c -> c.IsVip)

    let upgradeCustomer customer = 
        customer
        |> getPurchases
        |> tryPromoteToVip
        |> increaseCreditUsingVip

    let isAdult (customer : Customer) = 
        match customer.PersonalDetails with
        | None -> false
        | Some d -> d.DateOfBirth.AddYears 18 <= DateTime.Now.Date

    let getAlert (customer : Customer) = 
         match customer.Notifications with
         | ReceiveNotifications(receiveAlerts = true) -> sprintf "Alert for customer %i" customer.Id
         | _ -> ""