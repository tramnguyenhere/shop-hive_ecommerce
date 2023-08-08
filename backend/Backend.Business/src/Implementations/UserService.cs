using AutoMapper;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Implementations
{
    public class UserService : BaseService<User,  UserReadDto, UserCreateDto, UserUpdateDto>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepo, IMapper mapper) : base(userRepo, mapper)
        {
            _userRepository = userRepo;
        }

        public async Task<UserReadDto> UpdatePassword(string id, string newPassword)
        {
            var foundUser = await _userRepository.GetOneById(id);
            if (foundUser == null) {
                throw new Exception("User not found");
            }
            return _mapper.Map<UserReadDto>(_userRepository.UpdatePassword(foundUser, newPassword));
        }
    }
}