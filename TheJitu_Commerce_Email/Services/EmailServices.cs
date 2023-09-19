using Microsoft.EntityFrameworkCore;
using TheJitu_Commerce_Email.Data;
using TheJitu_Commerce_Email.Models;

namespace TheJitu_Commerce_Email.Services
{
    public class EmailServices
    {
        private DbContextOptions<AppDbContext> options;

        public EmailServices()
        {
        }

        public EmailServices(DbContextOptions<AppDbContext> options)
        {
            this.options = options;
        }


        public async Task SaveData(EmailLoggers emailLoggers)
        {
            //create _context

            var _context = new AppDbContext(this.options);
            _context.EmailLoggers.Add(emailLoggers);
            await _context.SaveChangesAsync();
        }
    }
}
