namespace FSharp.Playground.Workshop

module Functions = 

    open FSharp.Playground.Workshop.Types

    let getPurchases (customer : Customer) = 
        if customer.Id % 2 = 0 
            then (customer, 120M)
            else (customer, 80M)

    let tryPromoteToVip (customerWithPurchases : Customer * decimal) =
        let (customer, amount) = customerWithPurchases
        if (amount > 100M)
            then { customer with IsVip = true }
            else customer

    let increase condition customer = 
        if condition customer  
            then { customer with Credit = customer.Credit + 100M }
            else { customer with Credit = customer.Credit + 50M }

    let increaseCreditUsingVip = increase (fun c -> c.IsVip)