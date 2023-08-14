using System.Security.Claims;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller.src.Controllers
{
    [Authorize]
    public class OrderController : CrudController<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        private readonly IOrderService _orderService;
        private readonly IAuthorizationService _authorizationService;
        public OrderController(IOrderService orderService) : base(orderService)
        {
            _orderService = orderService;
        }
        public override async Task<ActionResult<OrderReadDto>> UpdateOneById([FromRoute] Guid id, [FromBody] OrderUpdateDto update){
            var user = HttpContext.User;
            var order = await base.GetOneById(id);
            return await _orderService.UpdateOneById(id, update);
        }
    }
}