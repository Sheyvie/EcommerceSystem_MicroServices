using TheJitu_Commerce_Cart.Models.Dtos;

namespace TheJitu_Commerce_Orders.Models.Dtos
{
    public class OrderDetailsDto
    {
        public Guid OrderDetailsId { get; set; }
        public Guid OrderHeaderId { get; set; }
        public Guid ProductId { get; set; }

        public ProductDto? Product { get; set; }
        public int Count { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}
