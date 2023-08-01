using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.src.Controllers.Domain.Entities
{
    public class Order : BaseEntity
    {
        [ForeignKey(nameof(Cart))]
        public Guid CartId { get; set; }
        public string Recipient { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [ForeignKey(nameof(Address))]
        public Guid AddressId { get; set; }
        public OrderStatus Status { get; set; }
    }
}