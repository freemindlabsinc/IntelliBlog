namespace Blogging.Domain.Aggregates.Articles;

public sealed class ArticleSource : HasDomainEventsBase
{
    internal static ArticleSource CreateNew(
        int articleId,
        int sourceId)
    {
        var articleSource = new ArticleSource();
        articleSource.ArticleId = articleId;
        articleSource.SourceId = sourceId;
        return articleSource;
    }

    public int Id { get; private set; } = default!; // It's never accessed directly so it does not need to be a strong id
    public int ArticleId { get; private set; } = default!;
    public int SourceId { get; private set; } = default!;        
    public DateTime LinkedOn { get; private set; } = DateTime.UtcNow;
}
