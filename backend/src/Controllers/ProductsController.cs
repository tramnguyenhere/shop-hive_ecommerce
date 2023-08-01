using Microsoft.AspNetCore.Mvc;

namespace backend.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> GetAllProducts() {
            return new[] { "" };
        }
        [HttpGet("{id:Guid}")]
        public string GetProductById() {
            return "";
        }
    }
}