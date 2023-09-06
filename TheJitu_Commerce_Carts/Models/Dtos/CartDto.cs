using TheJitu_Commerce_Cart.Models.Dtos;

namespace TheJitu_Commerce_Cart.Models.Dtos
{
    //a combination of cartheader and cartdetails
    public class CartDto
    { 
        public CartHeaderDto CartHeader { get; set; }
        public IEnumerable<CartDetailsDto>?CartDetails { get; set; } 
    }
}
