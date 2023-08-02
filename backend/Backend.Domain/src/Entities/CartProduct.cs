using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.src.Entities
{
    public class CartProduct : BaseEntityWithId
    {
        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(Cart))]
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
    }
}