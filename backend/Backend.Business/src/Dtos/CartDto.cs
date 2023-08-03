using System;
using Backend.Domain.src.Entities;

namespace Backend.Business.src.Dtos
{
    public class CartDto
    {
        public List<CartProduct> CartProducts { get; set; }
    }
}