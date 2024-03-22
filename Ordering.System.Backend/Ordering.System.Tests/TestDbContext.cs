using Microsoft.EntityFrameworkCore;
using Ordering.System.Api.Entities;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}