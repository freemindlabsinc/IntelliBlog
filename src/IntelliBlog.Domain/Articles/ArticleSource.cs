using IntelliBlog.Domain.Sources;

namespace IntelliBlog.Domain.Articles;

public class ArticleSource : Entity<int>
{
    public ArticleId ArticleId { get; private set; } = default!;
    public SourceId SourceId { get; private set; } = default!;
}
