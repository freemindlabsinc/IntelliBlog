namespace IntelliBlog.Domain;

public readonly record struct ArticleId(int Value)
{
    public static ArticleId Empty { get; } = default;
    public override string ToString() => StrongIdHelper<ArticleId, int>.Serialize(Value);
    public static ArticleId? TryParse(string? value) => StrongIdHelper<ArticleId, int>.Deserialize(value);

    public static implicit operator int(ArticleId id) => id.Value;
    public static implicit operator ArticleId(int id) => new ArticleId(id);
}
