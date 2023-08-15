using Backend.Business.src.Shared;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;
using Backend.Domain.src.Shared;
using Backend.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.src.RepoImplementations
{
    public class OrderProductRepository : BaseRepository<OrderProduct>, IOrderProductRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly DbSet<OrderProduct> _orderProducts;

        public OrderProductRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _orderProducts = dbContext.OrderProducts;
        }

        public async Task<IEnumerable<OrderProduct>> CreateListOfOrderProducts(params OrderProduct[] orderProducts)
        {
            await _orderProducts.AddRangeAsync(orderProducts);
            await _dbContext.SaveChangesAsync();
            return orderProducts;
        }

        public override async Task<IEnumerable<OrderProduct>> GetAll(QueryOptions queryOptions)
        {
            IQueryable<OrderProduct> query = _orderProducts;

            if (!string.IsNullOrWhiteSpace(queryOptions.Search))
            {
                query = query.Where(
                    orderProduct =>
                        orderProduct.Product.Title.ToLower().Contains(queryOptions.Search.ToLower())
                );
            }

            if (queryOptions.OrderByAscending && queryOptions.OrderByDescending)
            {
                throw new CustomException(
                    400,
                    "Both OrderByAscending and OrderByDescending cannot be true."
                );
            }
            else if (queryOptions.OrderByAscending)
            {
                query = query.OrderBy(orderProduct => orderProduct.Quantity);
            }
            else if (queryOptions.OrderByDescending)
            {
                query = query.OrderByDescending(orderProduct => orderProduct.Quantity);
            }

            if (queryOptions.Order == "Latest")
            {
                query = query.OrderByDescending(orderProduct => orderProduct.UpdatedAt);
            }
            else if (queryOptions.Order == "Earliest")
            {
                query = query.OrderBy(orderProduct => orderProduct.UpdatedAt);
            }

            if (queryOptions.PageNumber == 0)
            {
                return query;
            }
            else
            {
                query = query
                    .Skip((queryOptions.PageNumber - 1) * queryOptions.ItemPerPage)
                    .Take(queryOptions.ItemPerPage);
            }

            return await query.ToArrayAsync();
        }
    }
}