using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Dtos
{
    public class ReviewReadDto
    {
        public Product ProductId { get; set; }
        public User UserId { get; set; }
        public string Feedback { get; set; }
    }
    public class ReviewCreateDto
    {
        public Product ProductId { get; set; }
        public User UserId { get; set; }
        public string Feedback { get; set; }
    }
    public class ReviewUpdateDto
    {
        public string Feedback { get; set; }
    }
}