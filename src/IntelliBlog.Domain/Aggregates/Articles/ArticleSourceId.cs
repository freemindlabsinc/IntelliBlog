namespace IntelliBlog.Domain.Aggregates.Articles;

public readonly record struct ArticleSourceId(int Value)
{
    public static ArticleSourceId Empty { get; } = default;
    public override string ToString() => StrongIdHelper<ArticleSourceId, int>.Serialize(Value);
    public static ArticleSourceId? TryParse(string? value) => StrongIdHelper<ArticleSourceId, int>.Deserialize(value);

    public static implicit operator int(ArticleSourceId id) => id.Value;

    public static implicit operator ArticleSourceId(int id) => new ArticleSourceId(id);
}
