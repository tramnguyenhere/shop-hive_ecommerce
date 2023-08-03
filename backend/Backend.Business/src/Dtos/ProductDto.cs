using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Dtos
{
    public class ProductDto
    {
         public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public List<Image> Images { get; set; }
    }
}