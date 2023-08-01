using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.src.Controllers.Domain.Entities
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
}