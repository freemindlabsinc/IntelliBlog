using Blogging.Domain.Interfaces;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Infrastructure.Data.TestData;

public static class DatabaseSeeder
{
    public record GenerationOptions(
        BloggingDbContext DbContext,
        int BlogsCount,
        int SourcesCount,
        int PostsCount);

    public static async Task GenerateAsync(
        GenerationOptions options, 
        CancellationToken cancellationToken = default)
    { 
        var blogs = GenerateBlogs(options.BlogsCount);
        await options.DbContext.AddRangeAsync(blogs);
        
        var sources = GenerateSources(blogs, options.SourcesCount);
        await options.DbContext.AddRangeAsync(sources);
        
        var posts = GeneratePosts(blogs, options.PostsCount);
        await options.DbContext.AddRangeAsync(posts);

        // 
        await options.DbContext.SaveChangesAsync();
    }

    static Faker<T> CommonInitialization<T>(this Faker<T> faker)
        where T : class, ITrackedEntity
        => faker
            .UseSeed(777)
            .UseDateTimeReference(DateTime.Parse("1/1/1975"))
            .StrictMode(true)
            .RuleFor(x => x.CreatedOn, f => f.Date.Past())
            .RuleFor(x => x.CreatedBy, f => f.Internet.UserName())
            .RuleFor(x => x.LastModifiedOn, f => f.Date.Past())
            .RuleFor(x => x.LastModifiedBy, f => f.Internet.UserName())
            ;//.RuleFor(te => te.);
    
    static IEnumerable<Blog> GenerateBlogs(int amount)
    {
        int blogId = 100;

        var faker = new Faker<Blog>()
            .CommonInitialization()
                    
            .CustomInstantiator(f => new Blog(
                name: f.Lorem.Sentence(),
                description: f.Lorem.Paragraph()))
            .RuleFor<int>(x => x.Id, f => blogId++)            
            .RuleFor(x => x.Name, f => f.Lorem.Sentence())
            .RuleFor(x => x.Description, f => f.Lorem.Text())
            .RuleFor(x => x.Notes, f => f.Lorem.Paragraph())
            .RuleFor(x => x.Image, f => f.Image.PicsumUrl())
            .RuleFor(x => x.IsOnline, f => f.Random.Bool())
            .Ignore(x => x.Tags)
            ;

        var blogs = faker.Generate(amount);
        return blogs;
    }

    static IEnumerable<Source> GenerateSources(IEnumerable<Blog> blogs, int amount)
    { 
        var faker = new Faker<Source>()
            .CommonInitialization()

            .CustomInstantiator(f => new Source(
                blogId: f.PickRandom(blogs).Id,
                name: f.Lorem.Sentence()))

            .RuleFor(x => x.Url, f => f.Internet.Url())
            .RuleFor(x => x.Description, f => f.Lorem.Paragraph());

        return faker.Generate(amount);
    }

    static IEnumerable<Post> GeneratePosts(IEnumerable<Blog> blogs, int amount)
    {
        var faker = new Faker<Post>()
            .CommonInitialization()

            .CustomInstantiator(f => new Post(
                blogId: f.PickRandom(blogs).Id,
                title: f.Lorem.Sentence()))
            //.RuleFor(x => x.Content, f => f.Lorem.Paragraphs(3))
            //.RuleFor(x => x.PublishedDate, f => f.Date.Past())
            //.RuleFor(x => x.Url, f => f.Internet.Url())
            .RuleFor(x => x.Image, f => f.Image.PicsumUrl())
            .RuleFor(x => x.Description, f => f.Lorem.Sentence())
            ;

        return faker.Generate(amount);
    }
}
