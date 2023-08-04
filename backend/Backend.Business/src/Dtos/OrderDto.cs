using Backend.Domain.src.Entities;

namespace Backend.Business.src.Dtos
{
    public class OrderDto
    {
        public string? Recipient { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Address? Address { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}