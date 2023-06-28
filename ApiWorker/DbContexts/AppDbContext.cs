using ApiWorker.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWorker.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Worker> Workers { get; set; }
    }

}