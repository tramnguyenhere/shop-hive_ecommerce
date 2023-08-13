using AutoMapper;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Business.src.Shared;
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

        public async Task<UserReadDto> UpdatePassword(Guid id, string newPassword)
        {
            var foundUser = await _userRepository.GetOneById(id);
            if (foundUser == null) {
                throw new Exception("User not found");
            }
            PasswordService.HashPassword(newPassword, out var hashedPassword, out var salt);
            foundUser.Password = hashedPassword;
            foundUser.Salt = salt;
            return _mapper.Map<UserReadDto>(await _userRepository.UpdatePassword(foundUser));
        }

        public override async Task<UserReadDto> CreateOne(UserCreateDto entity) {
            var newEntity = _mapper.Map<User>(entity);
            PasswordService.HashPassword(entity.Password, out var hashedPassword, out var salt);
            newEntity.Password = hashedPassword;
            newEntity.Salt = salt;
            var createdEntity = await _userRepository.CreateOne(newEntity);
            return _mapper.Map<UserReadDto>(createdEntity);
        }

        public async Task<UserReadDto> CreateAdmin(UserCreateDto entity)
        {
            var newEntity = _mapper.Map<User>(entity);
            PasswordService.HashPassword(entity.Password, out var hashedPassword, out var salt);
            newEntity.Password = hashedPassword;
            newEntity.Salt = salt;
            var createdEntity = await _userRepository.CreateAdmin(newEntity);
            return _mapper.Map<UserReadDto>(createdEntity);
        }
    }
}