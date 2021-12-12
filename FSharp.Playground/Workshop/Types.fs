namespace FSharp.Playground.Workshop

module Types = 

    open System

    type PersonalDetails = {
        FirstName: string
        Lastname: string
        DateOfBirth: DateTime
    }

    [<Measure>] type EUR
    [<Measure>] type USD

    type Notifications =
        | NoNotifications
        | ReceiveNotifications of receiveDeals:bool * receiveAlerts:bool

    type Customer = {
        Id: int
        IsVip: bool
        Credit: decimal<EUR>
        PersonalDetails: PersonalDetails
        Notifications: Notifications
    }