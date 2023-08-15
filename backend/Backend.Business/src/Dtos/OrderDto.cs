using Backend.Domain.src.Entities;

namespace Backend.Business.src.Dtos
{
    public class OrderReadDto
    {
        public UserReadDto User { get; set; }
        public string Recipient { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderProductReadDto> OrderProducts { get; set; }
    }

    public class OrderCreateDto
    {
        public Guid UserId { get; set; }
        public string? Recipient { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public OrderStatus? Status { get; set; } = OrderStatus.Pending;
        public List<OrderProductCreateDto> OrderProducts { get; set; } = new List<OrderProductCreateDto>();
    }
    
    public class OrderUpdateDto
    {
        public string? Recipient { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public OrderStatus Status { get; set; }
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}