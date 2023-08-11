using Backend.Domain.src.Entities;

namespace Backend.Business.src.Dtos
{
    public class OrderReadDto
    {
        public string? Recipient { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }

    public class OrderCreateDto
    {
        public string? Recipient { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
    
    public class OrderUpdateDto
    {
        public string? Recipient { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}