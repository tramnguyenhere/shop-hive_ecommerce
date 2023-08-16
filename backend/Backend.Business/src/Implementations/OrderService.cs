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
        private readonly IUserRepository _userRepository;
        private readonly IOrderProductService _orderProductService;
        private readonly IProductRepository _productRepository;
        private readonly IOrderProductRepository _orderProductRepository;

        public OrderService(
            IOrderRepository orderRepo,
            IUserRepository userRepository,
            IOrderProductService orderProductService,
            IProductRepository productRepository,
            IOrderProductRepository orderProductRepository,
            IMapper mapper
        )
            : base(orderRepo, mapper)
        {
            _orderRepository = orderRepo;
            _userRepository = userRepository;
            _orderProductService = orderProductService;
            _productRepository = productRepository;
            _orderProductRepository = orderProductRepository;
        } 

        public override async Task<OrderReadDto> CreateOne(OrderCreateDto entity)
        {
            // Get the user to check if it is available
            var user = await _userRepository.GetOneById(entity.UserId);
            if (user == null)
            {
                throw CustomException.NotFoundException("User not found");
            }
            
            // Convert OrderCreateDto into Order
            var order = new Order
            {
                User = user,
                Recipient = string.IsNullOrEmpty(entity.Recipient)
                    ? $"{user.FirstName} {user.LastName}"
                    : entity.Recipient,
                Email = string.IsNullOrEmpty(entity.Email) ? user.Email : entity.Email,
                Address = string.IsNullOrEmpty(entity.Address) ? user.Address : entity.Address,
                PhoneNumber = string.IsNullOrEmpty(entity.PhoneNumber)
                    ? user.PhoneNumber
                    : entity.PhoneNumber,
                Status = OrderStatus.Pending,
                OrderProducts = new List<OrderProduct>()
            };

            // Insert Order into database
            var createdOrder = await _orderRepository.CreateOne(order);

            // Convert OrderProductCreateDto into OrderProduct
            var orderProducts = _mapper.Map<List<OrderProduct>>(entity.OrderProducts);

            // Map possible nullable property from previous convert
            for(int i = 0; i < orderProducts.Count(); i++ ) {
                var orderProductAtCurrentIndex = orderProducts.ElementAt(i);
                orderProductAtCurrentIndex.Order = createdOrder;
                orderProductAtCurrentIndex.Product = await _productRepository.GetOneById(entity.OrderProducts.ElementAt(i).ProductId);

                await _orderProductService.CreateOrderProduct(orderProductAtCurrentIndex);
            }

            var orderReadDto = new OrderReadDto {
                UserId = order.User.Id,
                Recipient = order.Recipient,
                PhoneNumber = order.PhoneNumber,
                Email = order.Email,
                Address = order.Address,
                Status = order.Status,
                OrderProducts = _mapper.Map<List<OrderProductReadDto>>(order.OrderProducts)
            };

            return orderReadDto;
        }

        // Only status of order is allowed to be updated.
        public override async Task<OrderReadDto> UpdateOneById(Guid id, OrderUpdateDto orderUpdateDto) {
            var foundOrder = await _orderRepository.GetOneById(id);

            if (foundOrder == null) {
                throw CustomException.NotFoundException("Order not found");
            }
            var user = foundOrder.User;

            var updatedOrder = _mapper.Map<Order>(orderUpdateDto);

            updatedOrder.Status = orderUpdateDto.Status;
            updatedOrder.Recipient = string.IsNullOrEmpty(orderUpdateDto.Recipient)
                    ? $"{user.FirstName} {user.LastName}"
                    : orderUpdateDto.Recipient;
            updatedOrder.PhoneNumber = string.IsNullOrEmpty(orderUpdateDto.PhoneNumber)
                    ? user.PhoneNumber
                    : orderUpdateDto.PhoneNumber;
            updatedOrder.Email = string.IsNullOrEmpty(orderUpdateDto.Email) ? user.Email : orderUpdateDto.Email;
            updatedOrder.Address = string.IsNullOrEmpty(orderUpdateDto.Address) ? user.Address : orderUpdateDto.Address;
            updatedOrder.OrderProducts = foundOrder.OrderProducts;
            updatedOrder.User = user;

            return _mapper.Map<OrderReadDto>(await _orderRepository.UpdateOneById(updatedOrder));
        }
    }
}
