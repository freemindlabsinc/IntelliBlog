namespace IntelliBlog.Domain.Aggregates.Articles;

public readonly record struct CommentId(int Value)
{ 
    public static CommentId Empty { get; } = default;
    public override string ToString() => StrongIdHelper<CommentId, int>.Serialize(Value);
    public static CommentId? TryParse(string? value) => StrongIdHelper<CommentId, int>.Deserialize(value);
}
