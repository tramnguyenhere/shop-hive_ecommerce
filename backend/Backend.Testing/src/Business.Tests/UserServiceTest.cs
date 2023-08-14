using System.Text;
using AutoMapper;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Business.src.Implementations;
using Backend.Business.src.Shared;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;
using Moq;

namespace src.Business.Tests
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly IUserService _userService;

        public UserServiceTest()
        {
           _userRepositoryMock = new Mock<IUserRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserCreateDto, User>();
                cfg.CreateMap<User, UserReadDto>();
            });

            var mapper = config.CreateMapper();
            _userService = new UserService(_userRepositoryMock.Object, mapper);
        }

        [Fact]
        public async Task CreateOne_ValidUser_ReturnsUserReadDto()
        {
            UserCreateDto createdUser = new()
            {
                FirstName = "Anna",
                LastName = "Le",
                Email = "anna@mail.com",
                PhoneNumber = "0123456787",
                Avatar = "avatar.png",
                Address = "129 AVC",
                Password = "abc123"
            };

            var mappedUser = new User() {
                FirstName = "Anna",
                LastName = "Le",
                Email = "anna@mail.com",
                PhoneNumber = "0123456787",
                Avatar = "avatar.png",
                Address = "129 AVC",
                Password = "abc123",
                Role = UserRole.Customer,
                Salt = Encoding.UTF8.GetBytes("salt")
            }; 

            _userRepositoryMock.Setup(repo => repo.CreateOne(It.IsAny<User>()))
                .ReturnsAsync(mappedUser);

            var result = await _userService.CreateOne(createdUser);

            Assert.NotNull(result);
            Assert.IsType<UserReadDto>(result);

            _userRepositoryMock.Verify(
                repo => repo.CreateOne(It.IsAny<User>()),
                Times.Once()
            );

            Assert.Equal(mappedUser.FirstName, result.FirstName);
            Assert.Equal(mappedUser.LastName, result.LastName);
            Assert.Equal(mappedUser.Email, result.Email);
            Assert.Equal(mappedUser.PhoneNumber, result.PhoneNumber);
            Assert.Equal(mappedUser.Avatar, result.Avatar);
            Assert.Equal(mappedUser.Address, result.Address);
            Assert.Equal(mappedUser.Role, result.Role);
        }

        [Fact]
        public async Task CreateAdmin_ValidUser_ReturnsUserReadDto()
        {
            UserCreateDto createdUser = new()
            {
                FirstName = "Anna",
                LastName = "Le",
                Email = "anna@mail.com",
                PhoneNumber = "0123456787",
                Avatar = "avatar.png",
                Address = "129 AVC",
                Password = "abc123"
            };

            var mappedUser = new User() {
                FirstName = "Anna",
                LastName = "Le",
                Email = "anna@mail.com",
                PhoneNumber = "0123456787",
                Avatar = "avatar.png",
                Address = "129 AVC",
                Password = "abc123",
                Role = UserRole.Admin,
                Salt = Encoding.UTF8.GetBytes("salt")
            }; 

            _userRepositoryMock.Setup(repo => repo.CreateAdmin(It.IsAny<User>()))
                .ReturnsAsync(mappedUser);

            var result = await _userService.CreateAdmin(createdUser);

            Assert.NotNull(result);
            Assert.IsType<UserReadDto>(result);

            _userRepositoryMock.Verify(
                repo => repo.CreateAdmin(It.IsAny<User>()),
                Times.Once()
            );

            Assert.Equal(mappedUser.FirstName, result.FirstName);
            Assert.Equal(mappedUser.LastName, result.LastName);
            Assert.Equal(mappedUser.Email, result.Email);
            Assert.Equal(mappedUser.PhoneNumber, result.PhoneNumber);
            Assert.Equal(mappedUser.Avatar, result.Avatar);
            Assert.Equal(mappedUser.Address, result.Address);
            Assert.Equal(mappedUser.Role, result.Role);
        }

        [Fact]
        public async Task UpdatePassword_UserFound_ReturnUserReadDto() {
            Guid userId = Guid.NewGuid();
            string newPassword = "newpassword";

            var foundUser = new User
            {
                Id = userId,
                FirstName = "Anna",
                LastName = "Le",
                Email = "anna@mail.com",
                PhoneNumber = "0123456787",
                Avatar = "avatar.png",
                Address = "129 AVC",
                Password = "abc123",
                Role = UserRole.Customer,
                Salt = Encoding.UTF8.GetBytes("salt")
            };

            _userRepositoryMock.Setup(repo => repo.GetOneById(userId))
                .ReturnsAsync(foundUser);

            var hashedPassword = "hashedpassword";
            var salt = new byte[32];

            PasswordService.HashPassword(newPassword, out hashedPassword, out salt);
            foundUser.Password = hashedPassword;
            foundUser.Salt = salt;

            _userRepositoryMock.Setup(repo => repo.UpdatePassword(It.IsAny<User>()))
                .ReturnsAsync(foundUser);

            var result = await _userService.UpdatePassword(userId, newPassword);

            Assert.NotNull(result);
            Assert.IsType<UserReadDto>(result);

            _userRepositoryMock.Verify(
                repo => repo.GetOneById(userId),
                Times.Once()
            );

            _userRepositoryMock.Verify(
                repo => repo.UpdatePassword(It.IsAny<User>()),
                Times.Once()
            );

            Assert.Equal(userId, foundUser.Id);
        }

        [Fact]
        public async Task UpdatePassword_UserNotFound_ThrowsNotFoundException() {
            Guid userId = Guid.NewGuid();
            string newPassword = "newpassword";

            _userRepositoryMock.Setup(repo => repo.GetOneById(userId))
                .ReturnsAsync((User)null);

            await Assert.ThrowsAsync<CustomException>(async () =>
            {
                await _userService.UpdatePassword(userId, newPassword);
            });

            _userRepositoryMock.Verify(
                repo => repo.GetOneById(userId),
                Times.Once()
            );

            _userRepositoryMock.Verify(
                repo => repo.UpdatePassword(It.IsAny<User>()),
                Times.Never()
            );
        }
    }
}