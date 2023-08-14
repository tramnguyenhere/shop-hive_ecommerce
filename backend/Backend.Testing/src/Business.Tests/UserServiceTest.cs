using System.Text;
using AutoMapper;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Dtos;
using Backend.Business.src.Implementations;
using Backend.Business.src.Shared;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Entities;
using Microsoft.AspNetCore.Identity;
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
            // Arrange
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
            }; // Initialize a mocked User instance

            _userRepositoryMock.Setup(repo => repo.CreateOne(It.IsAny<User>()))
                .ReturnsAsync(mappedUser);

            // Act
            var result = await _userService.CreateOne(createdUser);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UserReadDto>(result);
            // Add more assertions based on your specific requirements

            _userRepositoryMock.Verify(
                repo => repo.CreateOne(It.IsAny<User>()),
                Times.Once()
            );
        }
    }
}