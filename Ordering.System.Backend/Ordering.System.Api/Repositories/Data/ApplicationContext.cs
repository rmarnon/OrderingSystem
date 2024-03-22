using Microsoft.EntityFrameworkCore;
using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Repositories.Data
{
    public class ApplicationContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public ApplicationContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
