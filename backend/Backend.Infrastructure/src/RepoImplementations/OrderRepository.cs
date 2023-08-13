using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;
using Backend.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.src.RepoImplementations
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly DbSet<Order> _orders;
        private readonly DatabaseContext _dbContext;
        public OrderRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _orders = dbContext.Orders;
        }

         public async Task<Order> PlaceOrder(Order order)
        {
            await _orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }
    }
}