namespace Backend.Domain.src.Entities
{
    public class Order
    {
        public Cart CartId { get; set; }
        public string Recipient { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public OrderStatus Status { get; set; }
    }
}