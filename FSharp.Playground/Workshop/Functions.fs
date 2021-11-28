namespace FSharp.Playground.Workshop

module Functions = 

    open FSharp.Playground.Workshop.Types

    let getPurchases (customer : Customer) = 
        if customer.Id % 2 = 0 
            then (customer, 120M)
            else (customer, 80M)

    let increase condition customer = 
        if condition customer  
            then { customer with Credit = customer.Credit + 100M }
            else { customer with Credit = customer.Credit + 50M }

    let increaseCreditUsingVip = increase (fun c -> c.IsVip)