using System.ComponentModel.DataAnnotations.Schema;

namespace TheJitu_Commerce_Carts.Models
{
    public class CartHeader
    {
        public Guid CartHeaderId { get; set; } 
        public Guid UserId { get; set;}
        [NotMapped]
        public int Discount { get; set; }

    }
}
