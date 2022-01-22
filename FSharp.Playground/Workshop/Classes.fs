namespace FSharp.Playground.Workshop

module Classes = 

    open FSharp.Playground.Workshop.Types
    open FSharp.Playground.Workshop.Functions

    type CustomerServiceVerbose = class

        member x.UpgradeCustomer customer = 
            customer
            |> upgradeCustomer

    end

    type CustomerService() =
        member c.UpgradeCustomer customer =
            customer 
            |> upgradeCustomer

    type MyClassWithConstructor(dataIn) as s =
        let data = dataIn
        do
            s.PrintMessage()
        member this.PrintMessage() =
            printf "Creating MyClassWithConstructor with Data %d" data