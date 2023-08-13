using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.src.Entities
{
    public class Order : BaseEntityWithId
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public string? Recipient { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}