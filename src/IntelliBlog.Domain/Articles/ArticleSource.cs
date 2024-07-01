using IntelliBlog.Domain.Sources;

namespace IntelliBlog.Domain.Articles;

public class ArticleSource : Entity<int>
{
    public Article Article { get; private set; } = default!;
    public Source Source { get; private set; } = default!;
}
