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

        public OrderService(
            IOrderRepository orderRepo,
            IUserRepository userRepository,
            IOrderProductRepository orderProductRepository,
            IMapper mapper
        )
            : base(orderRepo, mapper)
        {
            _orderRepository = orderRepo;
            _userRepository = userRepository;
            _orderProductRepository = orderProductRepository;
        }

        public override async Task<OrderReadDto> CreateOne(OrderCreateDto order)
        {
            var foundUser = await _userRepository.GetOneById(order.UserId);

            if (foundUser == null)
            {
                throw CustomException.NotFoundException("User not found");
            }

            if (string.IsNullOrEmpty(order.Recipient))
            {
                order.Recipient = foundUser.FirstName + foundUser.LastName;
            }

            if (string.IsNullOrEmpty(order.PhoneNumber))
            {
                order.PhoneNumber = foundUser.PhoneNumber;
            }

            if (string.IsNullOrEmpty(order.Email))
            {
                order.Email = foundUser.Email;
            }

            if (string.IsNullOrEmpty(order.Address))
            {
                order.Address = foundUser.Address;
            }
            order.Status = OrderStatus.Pending;
            var orderProducts = new List<OrderProductCreateDto>();

            var createdOrder = await _orderRepository.CreateOne(_mapper.Map<Order>(order));

            foreach(var product in orderProducts) {
                product.OrderId = createdOrder.Id;
            }

            createdOrder.OrderProducts = _mapper.Map<List<OrderProduct>>(orderProducts);
            return _mapper.Map<OrderReadDto>(createdOrder);
        }
    }
}
