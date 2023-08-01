using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.src.Controllers.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string State { get; set; }
        [MinLength(6), MaxLength(6)]
        public string PostCode { get; set; }
    }
}