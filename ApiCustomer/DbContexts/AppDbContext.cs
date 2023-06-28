using AppCustomer.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCustomer.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}

