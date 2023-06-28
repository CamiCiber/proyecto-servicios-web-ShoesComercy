using ApiCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCompany.DbContexts

{
    public class AppDbContext : DbContext
    {

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
    }
}
