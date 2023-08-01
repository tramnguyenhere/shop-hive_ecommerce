using System.ComponentModel.DataAnnotations.Schema;

namespace backend.src.Controllers.Domain.Entities
{
    public class Review : BaseEntity
    {
        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public string Feedback { get; set; }

    }
}