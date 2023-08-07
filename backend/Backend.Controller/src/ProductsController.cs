using Backend.Business.src.Abstractions;
using Backend.Controller.src.Models;
using Backend.Domain.src.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller.src
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<GetAllProductsResponse> GetAllProducts([FromQuery] QueryOptions queryOptions)
        {
            if(queryOptions.PageNumber < 0 || queryOptions.ItemPerPage < 0) {
                return BadRequest("Page number or products per page cannot be negative");
            }

            var productDtos = _productService.GetAll(queryOptions);

            if (queryOptions.OrderByAscending && queryOptions.OrderByDescending)
            {
                return BadRequest("Both OrderByAscending and OrderByDescending cannot be true.");
            }
            else if (queryOptions.OrderByAscending)
            {
                productDtos = productDtos.OrderBy(product=>product.Title);
            }
            else if (queryOptions.OrderByDescending)
            {
                productDtos = productDtos.OrderByDescending(product=>product.Title);
            }

            if(queryOptions.PageNumber == 0) {
                return new GetAllProductsResponse(1, productDtos);
            }
            var result = productDtos.Skip((queryOptions.PageNumber - 1) * queryOptions.ItemPerPage).Take(queryOptions.ItemPerPage).ToList();
            int totalPages = productDtos.Count() / queryOptions.ItemPerPage;

            if (productDtos.Count() % queryOptions.ItemPerPage != 0) totalPages += 1;
            var response = new GetAllProductsResponse(totalPages, result);
            return Ok(response);
        }
    }
}
