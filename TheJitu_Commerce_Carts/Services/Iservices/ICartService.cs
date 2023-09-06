using TheJitu_Commerce_Cart.Models.Dtos;

namespace TheJitu_Commerce_Cart.Services.Iservices
{
    public interface ICartService
    {
        Task<bool> CartUpsert(CartDto cartDto);
        Task<CartDto> GetUserCart(Guid userId);
        Task<bool > ApplyCoupons(CartDto cartDto);
        Task<bool> RemoveFromCart(Guid CartDetailId); 
    }
}
