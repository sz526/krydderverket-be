using Microsoft.EntityFrameworkCore;
using Krydderverket.Models;

namespace Krydderverket.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}