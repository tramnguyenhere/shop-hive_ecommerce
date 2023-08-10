using Backend.Domain.src.Entities;

namespace Backend.Business.src.Dtos
{
    public class UserReadDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public UserRole Role { get; set; }
        public Address Address { get; set; }
    }

    public class UserCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public Address Address { get; set; }
        public string Password { get; set; }
    }
    
    public class UserUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public Address Address { get; set; }
    }

    public class UserCredentialsDto {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}