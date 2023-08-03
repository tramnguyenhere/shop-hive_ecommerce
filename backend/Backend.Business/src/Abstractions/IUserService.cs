using Backend.Business.src.Dtos;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Abstractions
{
    public interface IUserService : IBaseService<User, UserDto>
    {
        UserDto UpdatePassword(string id, string newPassword);
    }
}