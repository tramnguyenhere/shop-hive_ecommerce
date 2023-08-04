namespace Backend.Domain.src.Entities
{
    public class OrderProduct : BaseEntityWithId
    {
        public Product Product { get; set; }
        public Order OrderId { get; set; }
        public int Quantity { get; set; }
    }
}