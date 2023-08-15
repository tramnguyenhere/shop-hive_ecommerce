using Backend.Domain.src.Entities;

namespace Backend.Domain.src.Abstractions
{
    public interface IOrderProductRepository : IBaseRepository<OrderProduct>
    {
        // Task<OrderProduct> CreateOrderProduct(OrderProduct orderProduct);
        Task<IEnumerable<OrderProduct>> GetAllOrderProduct();
    }
}