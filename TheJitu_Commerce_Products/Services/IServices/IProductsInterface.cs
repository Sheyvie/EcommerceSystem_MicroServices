using TheJitu_Commerce_Products.Models;

namespace TheJitu_Commerce_Products.Services.IServices
{
    public interface IProductsInterface
    {
        Task<IEnumerable<Products>> GetProductsAsync();

        Task<Products> GetProductByIdAsync(Guid id);

        Task<Products> GetProductByNameAsync(string productName);

        Task<string> AddProductAsync(Products product);
        Task<string> UpdateProductAsync(Products product);
        Task<string> DeleteProductAsync(Products product);
                                                

    }
}
