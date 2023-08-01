using System.ComponentModel.DataAnnotations.Schema;
using backend.src.Controllers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Controllers
{
    [PrimaryKey(nameof(ProductId), nameof(ImageId))]
    public class ProductImage
    {
        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(Image))]
        public Guid ImageId { get; set; }
    }
}