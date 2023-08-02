using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.src.Entities
{
    public class Cart : BaseEntityWithId
    {
         [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public List<CartProduct> CartProducts { get; set; }
    }
}