namespace IntelliBlog.Domain.Articles;

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

public readonly record struct ArticleSourceId(int Value)
{
    public static ArticleSourceId Empty { get; } = default;
    public override string ToString() => StrongIdHelper<ArticleSourceId, int>.Serialize(Value);
    public static ArticleSourceId? TryParse(string? value) => StrongIdHelper<ArticleSourceId, int>.Deserialize(value);

    public static implicit operator int(ArticleSourceId id) => id.Value;

    public static implicit operator ArticleSourceId(int id) => new ArticleSourceId(id);
}
