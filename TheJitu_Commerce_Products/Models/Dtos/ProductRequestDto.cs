namespace TheJitu_Commerce_Products.Models.Dtos
{
    public class ProductRequestDto
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; }
        public double Price { get; set; }
    }
}
