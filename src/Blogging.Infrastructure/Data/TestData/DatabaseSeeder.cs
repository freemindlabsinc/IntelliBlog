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
        await options.DbContext.SaveChangesAsync();

        var sources = GenerateSources(blogs, options.SourcesCount);
        await options.DbContext.AddRangeAsync(sources);
        await options.DbContext.SaveChangesAsync();

        var posts = GeneratePosts(blogs, options.PostsCount);
        await options.DbContext.AddRangeAsync(posts);        

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

        string[] BlogStarters = {
            "A blog about",
            "The blog for",
            "The blog on"
        };

        var faker = new Faker<Blog>()
            .CommonInitialization()
                    
            .CustomInstantiator(f => new Blog(
                name: f.Random.Word().ToUpper(),
                description: $"{f.PickRandom(BlogStarters)} {f.Random.Words(2).ToLower()}"))
            .Ignore(x => x.Name)
            .Ignore(x => x.Description)
            
            .RuleFor<int>(x => x.Id, f => blogId++)
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
        var sourceId = 3000;
        var faker = new Faker<Source>()
            .CommonInitialization()

            .CustomInstantiator(f => new Source(
                blogId: f.PickRandom(blogs).Id,
                name: f.Random.Word()))
            
            .Ignore(x => x.BlogId)
            .Ignore(x => x.Name)

            .RuleFor(x => x.Type, f => f.PickRandom<SourceType>())
            .RuleFor(x => x.Image, f => f.Image.LoremFlickrUrl())

            .RuleFor<int>(x => x.Id, f => sourceId++)

            .RuleFor(x => x.Url, f => f.Internet.Url())
            .RuleFor(x => x.Description, f => f.Lorem.Paragraph())
            .Ignore(x => x.Tags);

        return faker.Generate(amount);
    }

    static IEnumerable<Post> GeneratePosts(IEnumerable<Blog> blogs, int amount)
    {
        string[] TitleStarters = {
            "Some thoughts about",
            "My ideas for",
            "An epiphany regarding"
        };

        string[] DescStarters = {
            "In this post I describe",
            "Some random thoughts about",
            "What if we"
        };

        var postId = 1000;

        var faker = new Faker<Post>()
            .CommonInitialization()

            .CustomInstantiator(f => new Post(
                blogId: f.PickRandom(blogs).Id,
                title: $"{f.PickRandom(TitleStarters)} {f.Random.Words(3).ToLower()}"))
            .RuleFor(x => x.Id, f => postId++)
            
            .RuleFor(x => x.Description, f => $"{f.PickRandom(DescStarters)} {f.Random.Words(3).ToLower()}")
            .Ignore(x => x.BlogId)
            .Ignore(x => x.Title)

            .RuleFor(x => x.Text, f => f.Lorem.Paragraphs(5))
            .RuleFor(x => x.IsPublished, f => f.Random.Bool())
            .RuleFor(x => x.State, f => f.PickRandom<PostState>())
            .RuleFor(x => x.Image, f => f.Image.PicsumUrl())
            .Ignore(x => x.Tags);
        ;

        return faker.Generate(amount);
    }
}
