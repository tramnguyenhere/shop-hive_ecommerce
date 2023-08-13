using Backend.Domain.src.Entities;

namespace Backend.Domain.src.Abstractions
{
    public interface IOrderProductRepository : IBaseRepository<OrderProduct>
    {
        IEnumerable<OrderProduct> CreateOrderProduct(params OrderProduct[] orderProducts);
    }
}