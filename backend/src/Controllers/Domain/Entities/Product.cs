using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.src.Controllers.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public int Inventory {get; set; }
    }
}