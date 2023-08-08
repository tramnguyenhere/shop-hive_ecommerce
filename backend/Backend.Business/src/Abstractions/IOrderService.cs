using Backend.Business.src.Dtos;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Abstractions
{
    public interface IOrderService : IBaseService<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        
    }
}