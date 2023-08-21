using System.Security.Claims;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Entities;
using Backend.Domain.src.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller.src.Controllers
{
    public class OrderController
        : CrudController<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        private readonly IOrderService _orderService;
        private readonly IOrderProductService _orderProductService;
        private readonly IAuthorizationService _authorizationService;

        public OrderController(
            IOrderService orderService,
            IAuthorizationService authorizationService,
            IOrderProductService orderProductService
        )
            : base(orderService)
        {
            _orderService = orderService;
            _authorizationService = authorizationService;
            _orderProductService = orderProductService;
        }

        [Authorize(Policy = "AdminRole")]
        public override async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAll([FromQuery] QueryOptions queryOptions) {
            return Ok(await _orderService.GetAll(queryOptions));
        }

        [Authorize]
        public override async Task<ActionResult<OrderReadDto>> CreateOne([FromBody] OrderCreateDto dto) {
            var userId = new Guid(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var createdObject = await _orderService.CreateOrder(userId, dto);
            // var createdObject = await _orderService.CreateOne(dto);
            return Ok(createdObject);
        }

        [Authorize]
        public override async Task<ActionResult<OrderReadDto>> UpdateOneById(
            [FromRoute] Guid id,
            [FromBody] OrderUpdateDto update
        )
        {
            var user = HttpContext.User;
            var order = await _orderService.GetOneById(id);

            var authorizeOwner = await _authorizationService.AuthorizeAsync(
                user,
                order,
                "OwnerOnly"
            );
            if (authorizeOwner.Succeeded)
            {
                return await base.UpdateOneById(id, update);
            }
            else
            {
                return new ForbidResult();
            }
        }

        [Authorize]
        [HttpPatch("{id:Guid}/confirm")]
        public async Task<ActionResult<OrderReadDto>> UpdateConfirmOrder(
            [FromRoute] Guid id,
            [FromBody] OrderUpdateDto update
        )
        {
            var user = HttpContext.User;
            var order = await _orderService.GetOneById(id);

            var authorizeOwner = await _authorizationService.AuthorizeAsync(user, order.UserId.ToString(), "OwnerOnly");
            if(authorizeOwner.Succeeded)
            {
            update.Status = OrderStatus.AwaitingPayment;
            return await base.UpdateOneById(id, update);
            }
            else
            {
                return new ForbidResult();
            }
        }

        [Authorize]
        [HttpPatch("{id:Guid}/payment-process")]
        public async Task<ActionResult<OrderReadDto>> UpdatePayment(
            [FromRoute] Guid id,
            [FromBody] OrderUpdateDto update
        )
        {
            var user = HttpContext.User;
            var order = await _orderService.GetOneById(id);

            var authorizeOwner = await _authorizationService.AuthorizeAsync(user, order.UserId.ToString(), "OwnerOnly");
            if(authorizeOwner.Succeeded)
            {
            update.Status = OrderStatus.AwaitingFulfillment;
            return await _orderService.UpdateOrderAwaitingForFulfillment(id, update);
            }
            else
            {
                return new ForbidResult();
            }
        }

        [HttpGet("{id:Guid}/products")]
        public async Task<ActionResult<IEnumerable<OrderProduct>>> GetAllProductsByOrder([FromRoute] Guid id) {
            return Ok(await _orderProductService.GetAllOrderProductForAnOrder(id));
        }
    }
}
