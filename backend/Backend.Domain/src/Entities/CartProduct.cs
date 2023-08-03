namespace Backend.Domain.src.Entities
{
    public class CartProduct : BaseEntityWithId
    {
        public Product Product { get; set; }
        public Cart CartId { get; set; }
        public int Quantity { get; set; }
    }
}