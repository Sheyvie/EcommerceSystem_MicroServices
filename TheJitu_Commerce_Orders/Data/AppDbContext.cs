
using Microsoft.EntityFrameworkCore;
using TheJitu_Commerce_Orders.Models;

namespace TheJitu_Commerce_Orders.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
    }

    
}
