namespace Backend.Domain.src.Entities
{
    public class Order : BaseEntityWithId
    {
        public User User { get; set; }
        // The reciepient and shipping address could be different from what has been stored in user database.
        public string? Recipient { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Address? Address { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}