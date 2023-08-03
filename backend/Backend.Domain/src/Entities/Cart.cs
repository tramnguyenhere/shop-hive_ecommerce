namespace Backend.Domain.src.Entities
{
    public class Cart : BaseEntityWithId
    {
        public User User { get; set; }
        public List<CartProduct> CartProducts { get; set; }
    }
}