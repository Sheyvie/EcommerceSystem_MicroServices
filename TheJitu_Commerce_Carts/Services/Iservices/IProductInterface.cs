using TheJitu_Commerce_Cart.Models.Dtos;

namespace TheJitu_Commerce_Cart.Services.Iservices
{
    public interface IProductInterface
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
    }
}
