using Microsoft.Extensions.DependencyInjection;
using Blogging.Infrastructure.Data;
using Infrastructure2.Data;

namespace Blogging.IntegrationTests.Data;

public class DbContextFixture : FixtureBase, IDisposable
{
    public DbContextFixture() : base() { }

    public void Dispose()
    {
        // Clean up the database
    }   

    public AppDbContext GetDbContext() => GetServiceProvider().GetService<AppDbContext>()!;
}
