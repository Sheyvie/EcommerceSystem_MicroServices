using System.ComponentModel.DataAnnotations;

namespace TheJitu_Commerce_Products.Models
{
    public class Products
    {
        [Key]
        public Guid ProductId { get; set; }



        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;



        [Range(0, int.MaxValue)]
        public double Price { get; set; }
        [Required]
        public string CategoryName { get; set; } = string.Empty;



        public string ImageUrl { get; set; } = string.Empty;
    }
}
