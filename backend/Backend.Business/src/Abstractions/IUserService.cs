using Backend.Business.src.Dtos;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Abstractions
{
    public interface IUserService : IBaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        Task<UserReadDto> UpdatePassword(Guid id, string newPassword);
        Task<UserReadDto> CreateAdmin(UserCreateDto entity);
        Task<UserReadDto> FindOneByEmail(string email);
    }
}