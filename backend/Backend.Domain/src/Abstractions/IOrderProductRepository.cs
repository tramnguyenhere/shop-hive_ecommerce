using Backend.Domain.src.Entities;

namespace Backend.Domain.src.Abstractions
{
    public interface IOrderProductRepository : IBaseRepository<OrderProduct>
    {
        Task<IEnumerable<OrderProduct>> CreateListOfOrderProducts(params OrderProduct[] orderProducts);
    }
}