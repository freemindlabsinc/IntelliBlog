﻿namespace Blogging.Infrastructure.Data;

public static class SeedData
{
    const string TechBlogName = "A technical blog";
    const string LovableBlogName = "A lovable Blog";

    public static async Task PopulateTestData(BloggingDbContext dbContext)
    {
        if (dbContext.Blogs.Any()) return;
        
        // ----------- Technical blog -----------
        await CreateTechBlog(dbContext);

        // ----------- Lovable blog -----------
        await CreateLovableBlog(dbContext);
    }

    static async Task CreateTechBlog(BloggingDbContext dbContext)
    {
        Blog techBlog = new Blog(TechBlogName, "A blog where I discuss topics I find interesting.");
        techBlog.UpdateNotes("This blog is about technical topics.");
        techBlog.UpdateImage("https://user-images.githubusercontent.com/63902621/82149019-72a07200-9873-11ea-8e58-b5b88dd58236.jpg");
        techBlog.AddTags("TECH", "WORK");        

        dbContext.Blogs.Add(techBlog);
        await dbContext.SaveChangesAsync();

        // Technical blog sources
        Source techSource1 = new Source(techBlog.Id, "YouTube", "http://youtu.be");        
        Source techSource2 = new Source(techBlog.Id, "The C# Guide", "http://csharpnews.org");
        Source techSource3 = new Source(techBlog.Id, "DDD Principles", "http://csharpnews.org");

        dbContext.Sources.AddRange(new[] { techSource1, techSource2 });
        await dbContext.SaveChangesAsync();

        // Technical blog articles
        Post techArticle1 = new Post(techBlog.Id, "Learning EF 8");
        techArticle1.AddTags("CSharp", "Programming");
        techArticle1.AddSources(techSource1.Id);

        Post techArticle2 = new Post(techBlog.Id, "Learning Test Driven Development");
        techArticle2.AddTags("TDD", "Programming");
        techArticle2.AddSources(techSource1.Id);

        Post techArticle3 = new Post(techBlog.Id, "Designing Aggregates");
        techArticle3.AddTags("DDD", "Design");
        techArticle3.AddSources(techSource1.Id);

        Post techArticle4 = new Post(techBlog.Id, "Designing Value Objects");
        techArticle4.AddTags("DDD", "Design");
        techArticle4.AddSources(techSource1.Id);

        dbContext.Posts.AddRange(techArticle1, techArticle2, techArticle3, techArticle4);
        await dbContext.SaveChangesAsync();

        PostComment comt1 = new PostComment(techArticle1.Id, "Great article!", "susan.carol@somewhere.com");
        PostComment comt2 = new PostComment(techArticle1.Id, "Great article, really informative!", "john.smith@somewhere.com");
        dbContext.PostComments.AddRange(new[] { comt1, comt2 });

        await dbContext.SaveChangesAsync();
    }

    static async Task CreateLovableBlog(BloggingDbContext dbContext)
    {
        Blog lovableBlog = new Blog(LovableBlogName, "A blog with lovely topics such as puppies and kittens.");
        lovableBlog.UpdateImage("https://4.bp.blogspot.com/-ixcfzBt0T5c/WKtt5MPCrVI/AAAAAAAABU8/URO5TXbUCGQnRb_XzEIzrUV3L5AG5hJKwCK4B/s1600/llb1.JPG");
        lovableBlog.AddTags("HOME");
        lovableBlog.UpdateNotes("This blog is about lovely topics such as puppies and kittens.");
        dbContext.Blogs.Add(lovableBlog);
        await dbContext.SaveChangesAsync();

        // Lovable blog sources
        Source lovalbleSource1 = new Source(lovableBlog.Id, "The Puppy Palace Online", "http://puppy.palace.com");
        Source lovalbleSource2 = new Source(lovableBlog.Id, "The Kitten Kindgom", "http://kitten.kingdom.com");

        dbContext.Sources.AddRange(new[] { lovalbleSource1, lovalbleSource2 });
        await dbContext.SaveChangesAsync();

        // Lovable blog articles
        Post lovalbleArticle1 = new Post(lovableBlog.Id, "How to groom a pug");
        lovalbleArticle1.AddTags("PUG");
        lovalbleArticle1.AddSources(lovalbleSource1.Id);

        Post lovalbleArticle2 = new Post(lovableBlog.Id, "How to pamper a pug");
        lovalbleArticle2.AddTags("PUG");
        lovalbleArticle1.AddSources(lovalbleSource2.Id);

        var articles = dbContext.Posts.AddRangeAsync(new[] { lovalbleArticle1, lovalbleArticle2 });
        await dbContext.SaveChangesAsync();
    }
}
