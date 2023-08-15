using Backend.Business.src.Shared;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;
using Backend.Domain.src.Shared;
using Backend.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.src.RepoImplementations
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly DbSet<Order> _orders;
        private readonly DatabaseContext _dbContext;

        public OrderRepository(DatabaseContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _orders = dbContext.Orders;
        }

        public override async Task<IEnumerable<Order>> GetAll(QueryOptions queryOptions)
        {
            IQueryable<Order> query = _orders;

            if (!string.IsNullOrWhiteSpace(queryOptions.Search))
            {
                query = query.Where(
                    order =>
                        order.OrderProducts.Any(
                            orderProduct =>
                                orderProduct.Product.Title
                                    .ToLower()
                                    .Contains(queryOptions.Search.ToLower())
                        )
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
                query = query.OrderBy(order => order.CreatedAt);
            }
            else if (queryOptions.OrderByDescending)
            {
                query = query.OrderByDescending(order => order.CreatedAt);
            }

            if (queryOptions.Order == "Latest")
            {
                query = query.OrderByDescending(order => order.UpdatedAt);
            }
            else if (queryOptions.Order == "Earliest")
            {
                query = query.OrderBy(order => order.UpdatedAt);
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
