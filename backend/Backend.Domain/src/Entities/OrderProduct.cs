using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.src.Entities
{
    public class OrderProduct : BaseEntity
    {
        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(Order))]
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
    }
}