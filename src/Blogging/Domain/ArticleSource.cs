namespace Blogging.Domain;

public sealed class ArticleSource : Entity<int>
{
    internal ArticleSource(int articleId, int sourceId)
    {
        ArticleId = articleId;
        SourceId = sourceId;        
    }

    //public int Id { get; private set; } = default!; // It's never accessed directly so it does not need to be a strong id
    public int ArticleId { get; private set; } = default!;
    public int SourceId { get; private set; } = default!;        
    public DateTime LinkedOn { get; private set; } = DateTime.UtcNow;
}
