using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;
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
    }
}