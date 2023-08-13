using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;
using Backend.Domain.src.Shared;
using Backend.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.src.RepoImplementations
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly DbSet<Product> _products;
        private readonly DatabaseContext _dbContext;
        public ProductRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _products = dbContext.Products;
        }

        public override async Task<IEnumerable<Product>> GetAll(QueryOptions queryOptions)
        {
            IQueryable<Product> query = _products;
    
            if (!string.IsNullOrWhiteSpace(queryOptions.Search))
            {
                query = query.Where(item => item.Title.ToLower().Contains(queryOptions.Search.ToLower()));
            }
            return await _products.ToArrayAsync();
        }
    }
}