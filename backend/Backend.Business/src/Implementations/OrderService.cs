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

        public async Task<OrderReadDto> CreateOrder(Guid userId, OrderCreateDto entity)
        {
            var user = await _userRepository.GetOneById(userId);
            if (user == null)
            {
                throw CustomException.NotFoundException("User not found");
            }

            var order = _mapper.Map<Order>(entity);

            order.Recipient = string.IsNullOrEmpty(entity.Recipient)
                    ? $"{user.FirstName} {user.LastName}"
                    : entity.Recipient;
            order.PhoneNumber = string.IsNullOrEmpty(entity.PhoneNumber)
                    ? user.PhoneNumber
                    : entity.PhoneNumber;
            order.Address = string.IsNullOrEmpty(entity.Address) ? user.Address : entity.Address;
            order.Email = string.IsNullOrEmpty(entity.Email) ? user.Email : entity.Email;
            order.OrderProducts = new List<OrderProduct>();
            order.User = user;
            order.Status = OrderStatus.Pending;

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

            var orderProductDtos = _mapper.Map<List<OrderProductReadDto>>(order.OrderProducts);

            var orderReadDto = _mapper.Map<OrderReadDto>(createdOrder);
            orderReadDto.OrderProducts = orderProductDtos;

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

        public override async Task<OrderReadDto> GetOneById(Guid id)
        {
            var foundItem = await _orderRepository.GetOneById(id);
            
            if(foundItem == null) {
                throw CustomException.NotFoundException("Item not found.");
            }

            var foundItemDto = _mapper.Map<OrderReadDto>(foundItem);
            foundItemDto.UserId = foundItem.User.Id;

            // var orderProducts = await _orderProductService.GetAllOrderProductForAnOrder(id);
            // var orderProductDtos = _mapper.Map<List<OrderProductReadDto>>(orderProducts);
            // foundItemDto.OrderProducts = orderProductDtos;

            return foundItemDto;
        }

        public async Task<OrderReadDto> UpdateOrderAwaitingForFulfillment(Guid id, OrderUpdateDto orderUpdateDto)
        {
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
