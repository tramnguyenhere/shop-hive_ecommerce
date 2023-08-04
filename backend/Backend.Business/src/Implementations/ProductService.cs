using AutoMapper;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Implementations
{
    public class ProductService : BaseService<Product, ProductDto>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepo, IMapper mapper) : base(productRepo, mapper)
        {
            _productRepository = productRepo;
        }
    }
}