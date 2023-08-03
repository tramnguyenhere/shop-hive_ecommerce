using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Dtos
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public UserRole Role { get; set; }
        public Address Address { get; set; }
    }
}