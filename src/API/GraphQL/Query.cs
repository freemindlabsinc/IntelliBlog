using Blogging.Domain.Aggregates.Articles;
using Blogging.Domain.Aggregates.Blogs;
using Blogging.Domain.Aggregates.Sources;
using Blogging.Infrastructure.Data;
using Humanizer.Localisation.DateToOrdinalWords;

namespace API.GraphQL;

[QueryType]
public class Query
{
    static readonly int[] _data = new int[] { 0, 1, 2, 3, 4 };

    [UseSelection]
    public IQueryable<int> GetBlogs(AppDbContext context)
        => _data.AsQueryable();
    
    //public IQueryable<Article> GetArticles([Service(ServiceKind.Synchronized)] AppDbContext context) =>
    //    context.Articles;
    //
    //public IQueryable<Source> GetSources([Service(ServiceKind.Synchronized)] AppDbContext context) =>
    //    context.Sources;
}
