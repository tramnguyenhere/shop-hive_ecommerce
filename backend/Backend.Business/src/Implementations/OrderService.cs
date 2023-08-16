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
        private readonly IProductRepository _productRepository;

        public OrderService(
            IOrderRepository orderRepo,
            IUserRepository userRepository,
            IOrderProductRepository orderProductRepository,
            IOrderProductService orderProductService,
            IProductRepository productRepository,
            IMapper mapper
        )
            : base(orderRepo, mapper)
        {
            _orderRepository = orderRepo;
            _userRepository = userRepository;
            _orderProductRepository = orderProductRepository;
            _orderProductService = orderProductService;
            _productRepository = productRepository;
        }

        public override async Task<OrderReadDto> CreateOne(OrderCreateDto entity)
        {
            var user = await _userRepository.GetOneById(entity.UserId);
            if (user == null)
            {
                throw CustomException.NotFoundException("User not found");
            }

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

            var createdOrder = await _orderRepository.CreateOne(order);
            var createdOrderReadDto = new OrderReadDto();

            if (entity.OrderProducts != null && entity.OrderProducts.Any())
            {
                var orderProducts = _mapper.Map<IEnumerable<OrderProduct>>(entity.OrderProducts);

                for (int i = 0; i < orderProducts.Count(); i++)
                {
                    var orderProductAtCurrentIndex = orderProducts.ElementAt(i);
                    orderProductAtCurrentIndex.Order = createdOrder;
                    orderProductAtCurrentIndex.Product = await _productRepository.GetOneById(
                        entity.OrderProducts.ElementAt(i).ProductId
                    );

                    var createdOrderProduct = await _orderProductRepository.CreateOne(
                        orderProductAtCurrentIndex
                    );

                    createdOrder.OrderProducts.Add(createdOrderProduct);
                }
                createdOrderReadDto = new OrderReadDto
                {
                    UserId = user.Id,
                    Recipient = createdOrder.Recipient,
                    Email = createdOrder.Email,
                    PhoneNumber = createdOrder.PhoneNumber,
                    Address = createdOrder.Address,
                    Status = createdOrder.Status,
                    OrderProducts = createdOrder.OrderProducts
                };
            }
            return createdOrderReadDto;
        }
    }
}
