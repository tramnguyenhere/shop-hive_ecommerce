using AutoMapper;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Business.src.Shared;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Implementations
{
    public class OrderService
        : BaseService<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>,
            IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderProductService _orderProductService;

        public OrderService(
            IOrderRepository orderRepo,
            IUserRepository userRepository,
            IOrderProductRepository orderProductRepository,
            IOrderProductService orderProductService,
            IMapper mapper
        )
            : base(orderRepo, mapper)
        {
            _orderRepository = orderRepo;
            _userRepository = userRepository;
            _orderProductRepository = orderProductRepository;
            _orderProductService = orderProductService;
        }

        public override async Task<OrderReadDto> CreateOne(OrderCreateDto order)
        {
            var newOrder = _mapper.Map<Order>(order);
            var user = await _userRepository.GetOneById(order.UserId);

            if (user == null)
            {
                throw CustomException.NotFoundException("User not found");
            }
            
            newOrder.Recipient = string.IsNullOrEmpty(order.Recipient)
                ? $"{user.FirstName} {user.LastName}"
                : order.Recipient;
            newOrder.Email = string.IsNullOrEmpty(order.Email) ? user.Email : order.Email;
            newOrder.Address = string.IsNullOrEmpty(order.Address) ? user.Address : order.Address;
            newOrder.PhoneNumber = string.IsNullOrEmpty(order.PhoneNumber)
                ? user.PhoneNumber
                : order.PhoneNumber;
            newOrder.Status = OrderStatus.Pending;

            newOrder.User = await _userRepository.GetOneById(order.UserId);

            var createdOrder = await _orderRepository.CreateOne(newOrder);

            foreach (var orderProduct in order.OrderProducts)
            {
                var newOrderProduct = await _orderProductService.CreateOrderProduct(orderProduct, createdOrder);

                await _orderProductRepository.CreateOne(newOrderProduct);
            }


            return _mapper.Map<OrderReadDto>(createdOrder);
        }
    }
}
