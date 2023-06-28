using Microsoft.EntityFrameworkCore;
using ApiBrand.Models;

namespace ApiBrand.DbContexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
    }
}
