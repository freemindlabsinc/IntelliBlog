using Infrastructure2.Data;
using Xunit.Abstractions;

namespace Blogging.IntegrationTests.Data;

public class DbContextTests
    : IClassFixture<DbContextFixture>
{
    private readonly ITestOutputHelper _outputHelper;
    private readonly DbContextFixture _fixture;

    public DbContextTests(DbContextFixture fixture, ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        _fixture = fixture;
        _fixture.SetTestOutputHelper(_outputHelper);
    }

    [Fact]
    public async Task Connects_to_db()
    {
        _fixture.Output?.WriteLine("Starting test");

        var dbContext = _fixture.GetDbContext();
        await dbContext.Database.EnsureCreatedAsync();
    }

    [Fact]
    public async Task Can_seed_test_data()
    {
        var dbContext = _fixture.GetDbContext();
        await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.EnsureCreatedAsync();

        await SeedData.PopulateTestData(dbContext);
    }    
}
