using Backend.Domain.src.Entities;

namespace Backend.Domain.src.Abstractions
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User CreateAdmin(User user);
    }
}