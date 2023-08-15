using System.Net;
using System.Security.Claims;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller.src.Controllers
{
    // [Authorize]
    public class OrderController : CrudController<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) : base(orderService)
        {
            _orderService = orderService;
        }
    }
}