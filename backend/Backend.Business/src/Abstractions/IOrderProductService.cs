using Backend.Business.src.Dtos;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Abstractions
{
    public interface IOrderProductService: IBaseService<OrderProduct,OrderProductReadDto, OrderProductCreateDto, OrderProductUpdateDto>
    {
        Task<IEnumerable<OrderProduct>> CreateListOfOrderProducts(params OrderProductCreateDto[] orderProductCreateDtos);
    }
}