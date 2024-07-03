using IntelliBlog.Domain.Sources;

namespace IntelliBlog.Domain.Articles;

public class ArticleSource : HasDomainEventsBase
{
    public static ArticleSource CreateNew(ArticleId articleId, SourceId sourceId)
    {
        var articleSource = new ArticleSource();
        articleSource.ArticleId = articleId;
        articleSource.SourceId = sourceId;
        return articleSource;
    }

    public ArticleId ArticleId { get; private set; } = default!;
    public SourceId SourceId { get; private set; } = default!;        
    public DateTime LinkedOn { get; private set; } = DateTime.UtcNow;
}
