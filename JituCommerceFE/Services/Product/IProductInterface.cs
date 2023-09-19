using JituCommerceFE.Models.Products;

namespace JituCommerceFE.Services.Product
{
    public interface IProductInterface


    {
        Task <List<ProductDto>> GetProductsAsync();
        Task<ProductDto> GetProductByIdAsync(Guid id);

    }
}
