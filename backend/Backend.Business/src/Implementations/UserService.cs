using AutoMapper;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Implementations
{
    public class UserService : BaseService<User, UserDto>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepo, IMapper mapper) : base(userRepo, mapper)
        {
            _userRepository = userRepo;
        }

        public UserDto UpdatePassword(string id, string newPassword)
        {
            var foundUser = _userRepository.GetOneById(id);
            if (foundUser == null) {
                throw new Exception("User not found");
            }
            return _mapper.Map<UserDto>(_userRepository.UpdatePassword(foundUser, newPassword));
        }
    }
}