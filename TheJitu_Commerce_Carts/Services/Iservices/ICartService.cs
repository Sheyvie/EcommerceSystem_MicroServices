using TheJitu_Commerce_Carts.Models.Dtos;

namespace TheJitu_Commerce_Carts.Services.Iservices
{
    public interface ICartService
    {
        Task<bool> CartUpsert(CartDto cartDto);
    }
}
