using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Controllers.Domain.Entities
{
    [PrimaryKey(nameof(ProductId), nameof(CartId))]
    public class CartProduct
    {
        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(Cart))]
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
    }
}