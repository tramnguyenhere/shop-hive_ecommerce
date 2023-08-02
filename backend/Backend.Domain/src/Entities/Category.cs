using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.src.Entities
{
    public class Category : BaseEntityWithId
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
}