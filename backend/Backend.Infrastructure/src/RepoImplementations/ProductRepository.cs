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

            if (queryOptions.OrderByAscending && queryOptions.OrderByDescending)
            {
                throw new Exception("Both OrderByAscending and OrderByDescending cannot be true.");
            }
            else if (queryOptions.OrderByAscending)
            {
                query = query.OrderBy(product => product.Title);
            }
            else if (queryOptions.OrderByDescending)
            {
                query = query.OrderByDescending(product => product.Title);
            }

            if(queryOptions.Order == "Latest") {
                query = query.OrderByDescending(product => product.UpdatedAt);
            } else if (queryOptions.Order == "Earliest") {
                query = query.OrderBy(product => product.UpdatedAt);
            }

            if(queryOptions.PageNumber == 0) {
                return query;
            } else {
                query = query.Skip((queryOptions.PageNumber - 1) * queryOptions.ItemPerPage).Take(queryOptions.ItemPerPage);
            }

            return await query.ToArrayAsync();
        }

        public override async Task<Product> CreateOne(Product entity)
        {
            return await base.CreateOne(entity);
        }
    }
}