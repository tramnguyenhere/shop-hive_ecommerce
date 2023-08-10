using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Entities;

namespace Backend.Controller.src.Controllers
{
    public class CategoryController : CrudController<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
    {
        public CategoryController(ICategoryService categoryService) : base(categoryService)
        {
        }
    }
}