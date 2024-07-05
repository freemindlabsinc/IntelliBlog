namespace IntelliBlog.Domain.Aggregates.Articles;

public class ArticleSource : HasDomainEventsBase
{
    internal static ArticleSource CreateNew(
        ArticleId articleId, 
        SourceId sourceId)
    {
        var articleSource = new ArticleSource();
        articleSource.ArticleId = articleId;
        articleSource.SourceId = sourceId;
        return articleSource;
    }

    public ArticleSourceId Id { get; private set; } = default!;
    public ArticleId ArticleId { get; private set; } = default!;
    public SourceId SourceId { get; private set; } = default!;        
    public DateTime LinkedOn { get; private set; } = DateTime.UtcNow;
}
