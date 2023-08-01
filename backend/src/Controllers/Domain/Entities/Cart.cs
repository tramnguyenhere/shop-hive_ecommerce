using System.ComponentModel.DataAnnotations.Schema;

namespace backend.src.Controllers.Domain.Entities
{
    public class Cart : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public List<CartProduct> CartProducts { get; set; }
    }
}