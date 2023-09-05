using Microsoft.EntityFrameworkCore;
using TheJitu_Commerce_Products.Models;

namespace TheJitu_Commerce_Products.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            
        }

        public DbSet<Products> Products { get; set; }
    }
}
