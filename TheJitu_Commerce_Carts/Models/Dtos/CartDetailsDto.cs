using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheJitu_Commerce_Cart.Models;

namespace TheJitu_Commerce_Cart.Models.Dtos
{
    public class CartDetailsDto
    {
        
        public Guid CartDetailsId { get; set; }

        public Guid CartHeaderId { get; set; }
        public CartHeader ?CartHeader { get; set; }

        public Guid? ProductId { get; set; }
        
        public ProductDto ?Product { get; set; }

        public int Count { get; set; }
    }
}
