using Backend.Business.src.Dtos;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Abstractions
{
    public interface IOrderProductService: IBaseService<OrderProduct,OrderProductReadDto, OrderProductCreateDto, OrderProductUpdateDto>
    {
        // Task<OrderProduct> CreateOrderProduct(OrderProductCreateDto dto, Order order);
        // Task<OrderProductReadDto> UpdateOrderProduct(OrderProductUpdateDto dto);
        // Task<bool> DeleteOrderProduct(Guid orderId, Guid productId);
        // Task<IEnumerable<OrderProductReadDto>> GetAllOrderProduct();
        // Task<OrderProductReadDto> GetOrderProductByIdComposition(Guid orderId, Guid productId);
    }
}