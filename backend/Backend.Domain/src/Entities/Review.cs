namespace Backend.Domain.src.Entities
{
    public class Review
    {
        public Product ProductId { get; set; }
        public User UserId { get; set; }
        public string Feedback { get; set; }
    }
}