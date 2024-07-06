using IntelliBlog.Domain.Aggregates.Articles;
using IntelliBlog.Domain.Aggregates.Blogs;
using IntelliBlog.Domain.Aggregates.Sources;
using IntelliBlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace IntelliBlog.IntegrationTests.Data;

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

    [Fact]
    public async Task Inserts_basic_data()
    { 
        var dbContext = _fixture.GetDbContext();

        // Creates the main aggregates
        var blog = Blog.CreateNew("TestBlog", "A blog created by a test");
        dbContext.Blogs.Add(blog);
        await dbContext.SaveChangesAsync();
        
        var article = Article.CreateNew(blog.Id, "Test").AddTags("TAG1", "TAG2");
        dbContext.Articles.Add(article);
        await dbContext.SaveChangesAsync();
        
        var source = Source.CreateNew(blog.Id, "Test source");
        dbContext.Sources.Add(source);
        await dbContext.SaveChangesAsync();
        
        // Links article and source
        article.AddSource(source.Id);
        dbContext.Sources.Update(source);
        await dbContext.SaveChangesAsync();

        // reads
        dbContext.ChangeTracker.Clear();
        var first = await dbContext.Articles
            .Where(a => a.Tags.Any(t => t.Name == "TAG2" ))
            .Where(a => a.Sources.Any(s => s.SourceId == source.Id))
            .FirstOrDefaultAsync();
        
        Assert.NotNull(first); _fixture.Output?.WriteLine("Completed test");
    }

    [Fact]
    public async Task Inserts_basic_data2()
    {
        var dbContext = _fixture.GetDbContext();

        // Creates the main aggregates
        var blog = Blog.CreateNew("TestBlog", "A blog created by a test");
        dbContext.Blogs.Add(blog);
        await dbContext.SaveChangesAsync();


    }
}
