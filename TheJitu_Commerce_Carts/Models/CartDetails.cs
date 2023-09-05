namespace TheJitu_Commerce_Carts.Models
{
    public class CartDetails
    {
        public Guid CartDetailsId { get; set; }

        public string CartHeaderId { get; set; }

        public CartHeader CartHeader { get; set; }

    }
}
