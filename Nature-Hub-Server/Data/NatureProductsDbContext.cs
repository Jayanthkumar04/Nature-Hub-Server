using Microsoft.EntityFrameworkCore;
using Nature_Hub_Server.Models;

namespace Nature_Hub_Server.Data
{
    public class NatureProductsDbContext:DbContext
    {
        public NatureProductsDbContext(DbContextOptions<NatureProductsDbContext> options):base(options)
        {
            
        }

        public DbSet<NatureProduct> NatureProducts { get; set; }

        public DbSet<Remedy> Remedies { get; set; }

        public DbSet<HealthTip> HealthTips { get; set; }

    }
}
