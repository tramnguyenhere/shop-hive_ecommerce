using System.ComponentModel.DataAnnotations;

namespace Backend.Domain.src.Entities
{
    public class Address
    {
        public string Street { get; set; }
        public string State { get; set; }
        [MinLength(6), MaxLength(6)]
        public string PostCode { get; set; }
    }
}