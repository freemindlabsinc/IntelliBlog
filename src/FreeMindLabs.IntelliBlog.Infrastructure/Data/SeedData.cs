using FreeMindLabs.IntelliBlog.Core.ArticleAggregate;
using FreeMindLabs.IntelliBlog.Core.ContributorAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FreeMindLabs.IntelliBlog.Infrastructure.Data;

public static class SeedData
{
    public static readonly Contributor Contributor1 = new("Ardalis");
    public static readonly Contributor Contributor2 = new("Snowfrog");

    public static readonly Article Article1 = new("Learning EF 8", ["CSharp", "Programming"]);
    public static readonly Article Article2 = new("Learning Test Driven Development", ["Programming"]);
    public static readonly Article Article3 = new("Learning Taoism", ["Philosophy"]);

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var dbContext = new AppDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
        {
            if (dbContext.Contributors.Any()) return;   // DB has been seeded

            PopulateTestData(dbContext);
        }
    }
    public static void PopulateTestData(AppDbContext dbContext)
    {
        foreach (var contributor in dbContext.Contributors)
        {
            dbContext.Remove(contributor);
        }
        dbContext.SaveChanges();

        dbContext.Contributors.Add(Contributor1);
        dbContext.Contributors.Add(Contributor2);

        // Articles
        foreach (var article in dbContext.Articles)
        {
            dbContext.Remove(article);
        }

        dbContext.Articles.Add(Article1);
        dbContext.Articles.Add(Article2);
        dbContext.Articles.Add(Article3);

        dbContext.SaveChanges();
    }
}
