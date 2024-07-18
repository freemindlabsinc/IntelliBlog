using Blogging.Domain.Aggregates.Articles;
using Blogging.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Articles;

[QueryType]
public class ArticleQueries
{
    [UsePaging]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public IQueryable<Article> GetArticles(
        [Service(ServiceKind.Synchronized)] AppDbContext db)
        => db.Articles.Include(x => x.Sources).Include(x => x.Comments);

    public Task<Article?> GetArticleById(
        [Service(ServiceKind.Synchronized)] AppDbContext db,
        [GraphQLType(typeof(IdType))] int id)
        => db.Articles.Include(x => x.Sources).Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
}
