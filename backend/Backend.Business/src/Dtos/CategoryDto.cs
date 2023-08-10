namespace Backend.Business.src.Dtos
{
    public class CategoryReadDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class CategoryCreateDto : CategoryReadDto
    {

    }

    public class CategoryUpdateDto : CategoryReadDto
    {

    }
}