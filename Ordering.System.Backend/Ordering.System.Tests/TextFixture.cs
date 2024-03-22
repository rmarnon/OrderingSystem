using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public class TestFixture
{
    public TestDbContext Context { get; private set; }

    public TestFixture()
    {
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlite()
            .BuildServiceProvider();

        var builder = new DbContextOptionsBuilder<TestDbContext>()
            .UseSqlite("DataSource=:memory:")
            .UseInternalServiceProvider(serviceProvider);

        Context = new TestDbContext(builder.Options);
        Context.Database.OpenConnection();
        Context.Database.EnsureCreated();
    }
}
