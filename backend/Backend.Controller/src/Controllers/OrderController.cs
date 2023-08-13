using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller.src.Controllers
{
    [Authorize]
    public class OrderController<OrderProductDto> : CrudController<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) : base(orderService)
        {
            _orderService = orderService;
        }
        
        [HttpPost()]
        public Order PlaceOrder([FromBody] IEnumerable<OrderProductDto> orderProductDtos)
        {
            var id = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            Console.WriteLine($"id: {id}");
            Console.WriteLine("order controller");
            var userId = new Guid(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
            Console.WriteLine($"userId: {userId}");
            /* call orderservice to save order */
            return _orderService.PlaceOrder(userId, orderProductDtos);
        }
    }
}