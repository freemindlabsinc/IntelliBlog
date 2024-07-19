using Blogging.Domain.Aggregates.Articles;
using Blogging.Domain.Specifications;
using Blogging.Infrastructure.Data;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Articles;

[QueryType]
public static class ArticleQueries
{
    [UsePaging]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public static IQueryable<Article> GetArticles(
        [Service(ServiceKind.Synchronized)] AppDbContext db)
    {
        PagedArticlesSpec spec = new PagedArticlesSpec(null, null, null, PagedArticlesSpec.ArticleIncludes.All);
        

        return db.Articles.Include(x => x.Sources).Include(x => x.Comments);
    }
    
    public static async Task<Article?> GetArticleById(
        int id,
        IArticleByIdDataLoader articleById,
        CancellationToken cancellationToken)
        => await articleById.LoadAsync(id, cancellationToken);
}
