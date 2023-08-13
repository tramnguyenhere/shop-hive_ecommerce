using AutoMapper;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Implementations
{
    public class OrderProductService : BaseService<OrderProduct, OrderProductDto, OrderProductDto, OrderProductDto>, IOrderProductService
    {
        private readonly IMapper _mapper;
        private readonly IOrderProductRepository _orderProductRepository;
        public OrderProductService(IOrderProductRepository orderProductRepo, IMapper mapper) : base(orderProductRepo, mapper)
        {
            _mapper = mapper;
            _orderProductRepository = orderProductRepo;
        }

        public Task<IEnumerable<OrderProduct>> CreateOrderProduct(IEnumerable<OrderProductDto> orderProductDto)
        {
            var orderProducts = _mapper.Map<IEnumerable<OrderProduct>>(orderProductDto);
            _orderProductRepository.CreateOrderProduct(orderProducts.ToArray());
            return (Task<IEnumerable<OrderProduct>>)orderProducts;
        }
    }
}