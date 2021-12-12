namespace FSharp.Playground.Workshop

module Functions = 

    open FSharp.Playground.Workshop.Types

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