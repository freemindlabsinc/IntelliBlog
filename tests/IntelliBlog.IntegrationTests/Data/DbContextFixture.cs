using Microsoft.Extensions.DependencyInjection;
using IntelliBlog.Infrastructure.Data;

namespace IntelliBlog.IntegrationTests.Data;

public class DbContextFixture : FixtureBase, IDisposable
{
    public DbContextFixture() : base() { }

    public void Dispose()
    {
        // Clean up the database
    }   

    public AppDbContext GetDbContext() => GetServiceProvider().GetService<AppDbContext>()!;
}
