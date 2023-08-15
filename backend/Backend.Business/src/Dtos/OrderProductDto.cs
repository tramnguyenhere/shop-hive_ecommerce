namespace Backend.Business.src.Dtos
{
    public class OrderProductReadDto
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
    }
    public class OrderProductCreateDto
    {
        public Guid? OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
    public class OrderProductUpdateDto
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
    }
}