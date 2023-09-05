using Microsoft.EntityFrameworkCore;
using TheJitu_Commerce_Products.Data;
using TheJitu_Commerce_Products.Models;
using TheJitu_Commerce_Products.Services.IServices;

namespace TheJitu_Commerce_Products.Services
{
    public class ProductService : IProductsInterface
        
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddProductAsync(Products product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return "Product Added Successfully";
                        
        }

        public async Task<string> DeleteProductAsync(Products product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return "Product deleted Successfully";

        }

        public async Task<Products> GetProductByIdAsync(Guid id)
        {
           return await _context.Products.FirstOrDefaultAsync(x=>x.ProductId == id);
        }

        public async Task<Products> GetProductByNameAsync(string productName)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Name.ToLower() == productName.ToLower());
        }

        public async Task<IEnumerable<Products>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<string> UpdateProductAsync(Products product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return "Product Updated Succesfully";
        }
    }
}
