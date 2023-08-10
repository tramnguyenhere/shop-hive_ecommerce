using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Entities;

namespace Backend.Controller.src.Controllers
{
    public class ProductController : CrudController<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) : base(productService)
        {
            _productService = productService;
        }
    }
}