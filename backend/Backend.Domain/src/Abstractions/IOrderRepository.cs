using Backend.Domain.src.Entities;

namespace Backend.Domain.src.Abstractions
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> PlaceOrder(Order order);
    }
}