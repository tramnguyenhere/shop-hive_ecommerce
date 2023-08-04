using AutoMapper;
using Backend.Business.src.Abstractions;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Implementations
{
    public class CategoryService : BaseService<Category, Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepo, IMapper mapper) : base(categoryRepo, mapper)
        {
            _categoryRepository = categoryRepo;
        }
    }
}