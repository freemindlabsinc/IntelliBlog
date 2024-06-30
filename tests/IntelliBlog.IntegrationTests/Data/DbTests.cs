using Ardalis.SharedKernel;
using IntelliBlog.Core.Domain.Article;
using IntelliBlog.Infrastructure;
using IntelliBlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;

namespace IntelliBlog.IntegrationTests.Data;
public class DbTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public async Task Connects_to_db()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.testing.json")
            .AddUserSecrets<BaseEfRepoTestFixture>()
            .Build();

        var _fakeEventDispatcher = Substitute.For<IDomainEventDispatcher>();

        using var serviceProvider = new ServiceCollection()
            .AddLogging((builder) => builder.AddXUnit(outputHelper))
            .AddSingleton<IDomainEventDispatcher>(_fakeEventDispatcher)
            .AddInfrastructureServices(config)
            .BuildServiceProvider();

        var dbctx = serviceProvider.GetService<AppDbContext>()!;
        await dbctx.Database.EnsureCreatedAsync();
        dbctx.Articles.Add(new Article("Test", ["TAG1", "TAG2"]));

        await dbctx.SaveChangesAsync();

        // db context 2
        var dbctx2 = serviceProvider.GetService<AppDbContext>()!;        
        var first = await dbctx2.Articles
            .Where(a => a.Tags.Contains("TAG2"))
            .FirstOrDefaultAsync();

        Assert.NotNull(first);
        outputHelper.WriteLine("ALL GOOD");
    }
}
