using AutoMapper;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Business.src.Shared;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;
using Backend.Domain.src.Shared;

namespace Backend.Business.src.Implementations
{
    public class OrderProductService : BaseService<OrderProduct, OrderProductReadDto, OrderProductCreateDto, OrderProductUpdateDto>, IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        public OrderProductService(IOrderProductRepository orderProductRepo, IOrderRepository orderRepository, IProductRepository productRepository, IMapper mapper) : base(orderProductRepo, mapper)
        {
            _orderProductRepository = orderProductRepo;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        // public async Task<OrderProduct> CreateOrderProduct(OrderProductCreateDto dto, Order order)
        // {
        //     bool productExists = order.OrderProducts.Any(p => p.Product.Id == dto.ProductId);

        //     if (productExists) {
        //         throw new CustomException(409, "The product is already in the order. Update instead of create new order product.");
        //     }

        //     var product = await _productRepository.GetOneById(dto.ProductId);
            
        //     product.Inventory -= dto.Quantity;
        //     await _productRepository.UpdateOneById(product);

        //     var newOrderProduct = _mapper.Map<OrderProduct>(dto);

        //     newOrderProduct.Product = product;
        //     newOrderProduct.Order = order;
        //     newOrderProduct.Quantity = dto.Quantity;

        //     var createdOrderProduct = await _orderProductRepository.CreateOne(newOrderProduct);
            
        //     return createdOrderProduct;
        // }

        public override async Task<OrderProductReadDto> CreateOne(OrderProductCreateDto dto)
        {
            var orderProduct = _mapper.Map<OrderProduct>(dto);
            var product = await _productRepository.GetOneById(dto.ProductId);

            if (product == null || product.Inventory < dto.Quantity) {
                throw CustomException.NotFoundException("Product not found or not enough for your order");
            }

            product.Inventory -= dto.Quantity;
            await _productRepository.UpdateOneById(product);

            return _mapper.Map<OrderProductReadDto>(await _orderProductRepository.CreateOne(orderProduct));   
        }

        public async Task<bool> DeleteOrderProduct(Guid orderId, Guid productId)
        {
            Guid id = CombineIdService.CombineIds(orderId, productId);

            var toBeDeletedProduct = await _orderProductRepository.GetOneById(id);

            if(toBeDeletedProduct != null) {
                await _orderProductRepository.DeleteOneById(toBeDeletedProduct);
                return true;
            }
            return false;
            throw CustomException.NotFoundException("Item not found"); 

        }

        public async Task<IEnumerable<OrderProductReadDto>> GetAllOrderProduct()
        {
            return (IEnumerable<OrderProductReadDto>)_mapper.Map<OrderProductReadDto>(await _orderProductRepository.GetAllOrderProduct());
        }

        public async Task<OrderProductReadDto> GetOrderProductByIdComposition(Guid orderId, Guid productId)
        {
            Guid id = CombineIdService.CombineIds(orderId, productId);
            var foundItem =  await _orderProductRepository.GetOneById(id);
            if(foundItem != null) {
                return _mapper.Map<OrderProductReadDto>(foundItem);
            } else {
                throw CustomException.NotFoundException("Item not found");
            }
        }

        // public async Task<OrderProductReadDto> UpdateOrderProduct(OrderProductUpdateDto dto)
        // {
        //     var product = await _productRepository.GetOneById(dto.ProductId);
        //     var order = await _orderRepository.GetOneById(dto.OrderId);

        //     product.Inventory -= dto.Quantity;
        //     await _productRepository.UpdateOneById(product);
            
        //     foreach(var item in order.OrderProducts) {
        //         if(item.Product.Id == dto.ProductId) {
        //             item.Quantity = dto.Quantity;
        //         }
        //     }

        //     await _orderRepository.UpdateOneById(order);

        //     var updatedOrderProduct = await _orderProductRepository.UpdateOneById(_mapper.Map<OrderProduct>(dto));
        //     return _mapper.Map<OrderProductReadDto>(updatedOrderProduct);
        // }

    }
}