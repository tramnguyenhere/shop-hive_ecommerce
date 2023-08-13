namespace Backend.Business.src.Dtos
{
    public class CategoryReadDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public string Image { get; set; } = string.Empty;
    }

    public class CategoryUpdateDto
    {
        public string Name { get; set; }
        public string Image { get; set; } = string.Empty;
    }
}