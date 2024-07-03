namespace IntelliBlog.Domain.Blogs;

public readonly record struct BlogId(int Value)
{
    public static BlogId Empty { get; } = default;
    public override string ToString() => StrongIdHelper<BlogId, int>.Serialize(Value);
    public static BlogId? TryParse(string? value) => StrongIdHelper<BlogId, int>.Deserialize(value);
}
