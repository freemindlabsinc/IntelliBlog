namespace Blogging.Domain.Aggregates;

public readonly record struct ArticleId(int Value)
{
    public static ArticleId Empty { get; } = default;
    
    public static implicit operator int(ArticleId id) => id.Value;
    public static implicit operator ArticleId(int id) => new ArticleId(id);
}
