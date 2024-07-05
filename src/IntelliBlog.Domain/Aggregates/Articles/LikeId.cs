namespace IntelliBlog.Domain.Aggregates.Articles;

public readonly record struct LikeId(int Value)
{
    public static LikeId Empty { get; } = default;
    public override string ToString() => StrongIdHelper<LikeId, int>.Serialize(Value);
    public static LikeId? TryParse(string? value) => StrongIdHelper<LikeId, int>.Deserialize(value);
}
