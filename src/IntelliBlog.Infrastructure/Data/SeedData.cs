﻿using IntelliBlog.Domain.Articles;
using IntelliBlog.Domain.Contributor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntelliBlog.Infrastructure.Data;

public static class SeedData
{
    public static readonly Contributor Contributor1 = new("Ardalis");
    public static readonly Contributor Contributor2 = new("Snowfrog");

    public static readonly Article Article1 = Article.CreateNew("Learning EF 8").AddTags("CSharp", "Programming");
    public static readonly Article Article2 = Article.CreateNew("Learning Test Driven Development").AddTags("TDD", "Programming");
    public static readonly Article Article3 = Article.CreateNew("Learning Taoism").AddTags("Philosophy");

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