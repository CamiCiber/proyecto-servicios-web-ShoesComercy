using Microsoft.EntityFrameworkCore;
using ApiShoes.Models;

namespace ApiShoes.DbContexts
{
    public class AppDbContext : DbContext
    {

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Shoes> shoess { get; set; }
    }
}
