using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;
using Backend.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.src.RepoImplementations
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly DbSet<Category> _categories;
        private readonly DatabaseContext _databaseContext;
        public CategoryRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _databaseContext = dbContext;
            _categories = dbContext.Categories;
        }
    }
}