using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.src.Entities;
using Backend.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.src.RepoImplementations
{
    public class OrderProductRepository : BaseRepository<OrderProduct>
    {
        private readonly DatabaseContext _dbContext;
        private readonly DbSet<OrderProduct> _orderProducts;

        public OrderProductRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _orderProducts = dbContext.OrderProducts;
        }

        public async Task<IEnumerable<OrderProduct>> CreateOrderproduct(params OrderProduct[] orderProducts)
        {
            await _orderProducts.AddRangeAsync(orderProducts);
            await _dbContext.SaveChangesAsync();
            return orderProducts;
        }
    }
}