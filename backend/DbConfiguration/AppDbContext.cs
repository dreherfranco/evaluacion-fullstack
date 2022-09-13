using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.DbConfiguration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Client> Clients { get; set; }


    }
}
