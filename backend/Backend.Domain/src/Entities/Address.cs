using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.src.Entities
{
    public class Address : BaseEntityWithId
    {
        public string Street { get; set; }
        public string State { get; set; }
        [MinLength(6), MaxLength(6)]
        public string PostCode { get; set; }
    }
}