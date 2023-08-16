using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller.src.Controllers
{
    // [Authorize]
    public class OrderController
        : CrudController<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        private readonly IOrderService _orderService;
        private readonly IAuthorizationService _authorizationService;

        public OrderController(
            IOrderService orderService,
            IAuthorizationService authorizationService
        )
            : base(orderService)
        {
            _orderService = orderService;
            _authorizationService = authorizationService;
        }

        // Update by user and admin
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

        // Update by user and admin
        // [Authorize]
        [HttpPatch("{id:Guid}/confirm")]
        public async Task<ActionResult<OrderReadDto>> UpdateConfirmOrder(
            [FromRoute] Guid id,
            [FromBody] OrderUpdateDto update
        )
        {
            // var user = HttpContext.User;
            // var order = await _orderService.GetOneById(id);

            // var authorizeOwner = await _authorizationService.AuthorizeAsync(user, order, "OwnerOnly");
            // if(authorizeOwner.Succeeded)
            // {
            update.Status = OrderStatus.AwaitingPayment;
            return await base.UpdateOneById(id, update);
            // }
            // else
            // {
            //     return new ForbidResult();
            // }
        }

        // Update by user and admin
        // [Authorize]
        [HttpPatch("{id:Guid}/payment-process")]
        public async Task<ActionResult<OrderReadDto>> UpdatePayment(
            [FromRoute] Guid id,
            [FromBody] OrderUpdateDto update
        )
        {
            // var user = HttpContext.User;
            // var order = await _orderService.GetOneById(id);

            // var authorizeOwner = await _authorizationService.AuthorizeAsync(user, order, "OwnerOnly");
            // if(authorizeOwner.Succeeded)
            // {
            update.Status = OrderStatus.AwaitingFulfillment;
            return await base.UpdateOneById(id, update);
            // }
            // else
            // {
            //     return new ForbidResult();
            // }
        }
    }
}
