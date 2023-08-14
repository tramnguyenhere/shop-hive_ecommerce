using Microsoft.AspNetCore.Authorization;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Entities;
using Microsoft.AspNetCore.Mvc;
using Backend.Domain.src.Shared;
using System.Security.Claims;

namespace Backend.Controller.src.Controllers
{
    public class UserController : CrudController<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) : base(userService) {
            _userService = userService;
        }

        [Authorize(Policy = "AdminRole")]
        public override async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll([FromQuery] QueryOptions queryOptions) {
            return Ok(await _userService.GetAll(queryOptions));
        }

        [Authorize(Policy = "AdminRole")]
        [HttpPost("admin")]
        public async Task<ActionResult<UserReadDto>> CreateAdmin([FromBody] UserCreateDto dto) {
            var createdObject = await _userService.CreateAdmin(dto);
            return CreatedAtAction(nameof(CreateAdmin), createdObject);
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetProfile() {
            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(await _userService.GetOneById(new Guid(id)));
        }

        [Authorize(Policy = "AdminRole")]
        [HttpGet("{email}")]
        public async Task<ActionResult<UserReadDto>> GetUserByEmail(string email)
        { 
            return Ok(await _userService.FindOneByEmail(email));
        }
    }
}