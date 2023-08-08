using Backend.Business.src.Dtos;

namespace Backend.Controller.src.Models
{
    public class GetAllProductsResponse
    {
        public int TotalPages { get; set; }
        public IEnumerable<ProductReadDto> Products { get; set; }
        public GetAllProductsResponse(int totalPages, IEnumerable<ProductReadDto> products)
        {
            TotalPages = totalPages;
            Products = products;
        }
    }
}