using AutoMapper;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Implementations
{
    public class ProductService : BaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository productRepo, ICategoryRepository categoryRepository, IMapper mapper) : base(productRepo, mapper)
        {
            _productRepository = productRepo;
            _categoryRepository = categoryRepository;
        }

        public override async Task<ProductReadDto> CreateOne(ProductCreateDto entity)
        {
            var category = await _categoryRepository.GetOneById(entity.CategoryId);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            var product = new Product
            {
                Title = entity.Title,
                Price = entity.Price,
                Description = entity.Description,
                Category = category,
                ImageUrl = entity.ImageUrl,
                Inventory = entity.Inventory
            };
            var createdProduct = await _productRepository.CreateOne(product);
            return _mapper.Map<ProductReadDto>(createdProduct);
        }

    }
}