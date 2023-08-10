using Backend.Domain.src.Entities;

namespace Backend.Business.src.Dtos
{
    public class ProductReadDto
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public List<Image> Images { get; set; }
    }

    public class ProductCreateDto
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public List<Image> Images { get; set; }
        public int Inventory { get; set; }
    }

    public class ProductUpdateDto
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public int Inventory { get; set; }
        public List<Image> Images { get; set; }
    }
}