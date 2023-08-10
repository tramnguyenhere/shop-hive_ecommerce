using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controller.src.Controllers
{
    public class ProductController : CrudController<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) : base(productService)
        {
            _productService = productService;
        }

        [Authorize]
        public override async Task<ActionResult<IEnumerable<ProductReadDto>>> CreateOne([FromBody] ProductCreateDto dto) {
            var createdObject = await _productService.CreateOne(dto);
            return CreatedAtAction("Created", createdObject);
        }

        [Authorize]
        public override async Task<ActionResult<ProductReadDto>> UpdateOneById ([FromRoute] string id, [FromBody] ProductUpdateDto update) {
            var updatedObject = await _productService.UpdateOneById(id, update);
            return Ok(updatedObject);
        }

        [Authorize]
        public override async Task<ActionResult<bool>> DeleteOneById([FromRoute] string id) {
            return StatusCode(204, await _productService.DeleteOneById(id));
        }
    }
}