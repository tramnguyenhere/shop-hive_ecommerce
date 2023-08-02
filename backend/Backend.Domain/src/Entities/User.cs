using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.src.Entities
{
    public class User : BaseEntityWithId
    {
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public UserRole Role { get; set; }
        public string Address { get; set; }
        public byte[] Password { get; set; }
    }
}