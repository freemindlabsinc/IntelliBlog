using Blogging.Domain.Aggregates.Articles;

namespace Blogging.Domain.Specifications;

public class PagedArticlesSpec : Specification<Article>
{
    [Flags]
    public enum ArticleIncludes
    { 
        None     = 0,
        Tags     = 1,
        Sources  = 2,
        Comments = 4,
        All      = Tags | Sources | Comments
    }

    public PagedArticlesSpec(int? skip, int? take = 10, string? filter = default, ArticleIncludes includes = ArticleIncludes.None)
    {
        if (skip.HasValue)
            Query.Skip(skip.Value);

        if (take.HasValue)
            Query.Take(take.Value);

        if (includes.HasFlag(ArticleIncludes.Tags))
            Query.Include(article => article.Tags);

        if (includes.HasFlag(ArticleIncludes.Sources))
            Query.Include(article => article.Sources);

        if (includes.HasFlag(ArticleIncludes.Comments))
            Query.Include(article => article.Comments);

        // TODO implement filter
    }
}
