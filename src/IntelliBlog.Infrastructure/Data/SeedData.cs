using IntelliBlog.Domain.Aggregates.Articles;
using IntelliBlog.Domain.Aggregates.Blogs;
using IntelliBlog.Domain.Aggregates.Sources;
using Microsoft.EntityFrameworkCore;

namespace IntelliBlog.Infrastructure.Data;

public static class SeedData
{
    const string TechBlogName = "A technical blog";
    const string LovableBlogName = "A lovable Blog";

    public static async Task PopulateTestData(AppDbContext dbContext)
    {
        // ----------- Technical blog -----------
        await CreateTechBlog(dbContext);

        // ----------- Lovable blog -----------
        await CreateLovableBlog(dbContext);
    }

    static async Task CreateTechBlog(AppDbContext dbContext)
    {
        Blog techBlog = Blog.CreateNew(TechBlogName, "A blog where I discuss topics I find interesting.");

        dbContext.Blogs.Add(techBlog);
        await dbContext.SaveChangesAsync();

        // Technical blog sources
        Source techSource1 = Source.CreateNew(techBlog.Id, "YouTube", "http://youtu.be");
        Source techSource2 = Source.CreateNew(techBlog.Id, "The C# Guide", "http://csharpnews.org");
        Source techSource3 = Source.CreateNew(techBlog.Id, "DDD Principles", "http://csharpnews.org");

        dbContext.Sources.AddRange(new[] { techSource1, techSource2 });
        await dbContext.SaveChangesAsync();

        // Technical blog articles
        Article techArticle1 = Article.CreateNew(techBlog.Id, "Learning EF 8")
            .AddTags("CSharp", "Programming")
            .AddSources(techSource1.Id);

        Article techArticle2 = Article.CreateNew(techBlog.Id, "Learning Test Driven Development")
            .AddTags("TDD", "Programming")
            .AddSources(techSource1.Id);

        Article techArticle3 = Article.CreateNew(techBlog.Id, "Designing Aggregates")
            .AddTags("DDD", "Design")
            .AddSources(techSource1.Id);

        Article techArticle4 = Article.CreateNew(techBlog.Id, "Designing Value Objects")
            .AddTags("DDD", "Design")
            .AddSources(techSource1.Id);

        dbContext.Articles.AddRange(techArticle1, techArticle2, techArticle3, techArticle4);
        await dbContext.SaveChangesAsync();
    }

    static async Task CreateLovableBlog(AppDbContext dbContext)
    {
        Blog lovableBlog = Blog.CreateNew(LovableBlogName, "A blog with lovely topics such as puppies and kittens.");
        dbContext.Blogs.Add(lovableBlog);
        await dbContext.SaveChangesAsync();

        // Lovable blog sources
        Source lovalbleSource1 = Source.CreateNew(lovableBlog.Id, "The Puppy Palace Online", "http://puppy.palace.com");
        Source lovalbleSource2 = Source.CreateNew(lovableBlog.Id, "The Kitten Kindgom", "http://kitten.kingdom.com");

        dbContext.Sources.AddRange(new[] { lovalbleSource1, lovalbleSource2 });
        await dbContext.SaveChangesAsync();

        // Lovable blog articles
        Article lovalbleArticle1 = Article.CreateNew(lovableBlog.Id, "How to groom a pug").AddTags("PUG");
        lovalbleArticle1.AddSource(lovalbleSource1.Id);

        Article lovalbleArticle2 = Article.CreateNew(lovableBlog.Id, "How to pamper a pug").AddTags("PUG");
        lovalbleArticle1.AddSource(lovalbleSource2.Id);

        var articles = dbContext.Articles.AddRangeAsync(new[] { lovalbleArticle1, lovalbleArticle2 });
        await dbContext.SaveChangesAsync();
    }
}
