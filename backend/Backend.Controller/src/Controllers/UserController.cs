using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Entities;

namespace Backend.Controller.src.Controllers
{
    public class UserController : CrudController<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) : base(userService) {
            _userService = userService;
        }

        
    }
}