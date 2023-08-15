using System.Drawing;
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

        // public async Task<OrderProduct> CreateOrderProduct(OrderProduct orderProduct)
        // {
        //     await _orderProducts.AddAsync(orderProduct);
        //     await _dbContext.SaveChangesAsync();
        //     return orderProduct;
        // }

        public override async Task<OrderProduct> CreateOne(OrderProduct entity)
        {
            return await base.CreateOne(entity);
        }

        public async Task<IEnumerable<OrderProduct>> GetAllOrderProduct()
        {
            return await _orderProducts.AsNoTracking().ToArrayAsync();
        }
    }
}