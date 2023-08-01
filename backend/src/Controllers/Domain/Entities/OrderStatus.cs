namespace backend.src.Controllers.Domain.Entities
{
    public enum OrderStatus
    {
        Pending, 
        AwaitingPayment, 
        AwaitingFulfillment,
        AwaitingShipment,
        AwaitingPickup, 
        AwaitingReturn,
        Shipped, 
        Cancelled, 
        Declined, 
        Refunded,
        Returned,
        Completed 
    }
}