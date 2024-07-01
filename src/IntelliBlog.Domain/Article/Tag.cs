namespace IntelliBlog.Domain.Article;

public readonly record struct TagId(int Value)
{
    public static TagId Empty { get; } = default;
    public override string ToString() => StrongIdHelper<TagId, int>.Serialize(Value);
    public static TagId? TryParse(string? value) => StrongIdHelper<TagId, int>.Deserialize(value);
}

public class Tag : Entity<TagId>
{
    internal  static Tag CreateNew(string name)
        => new Tag(name);

    public string Name { get; private set; } = default!;

    private Tag(string name)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
    }
}
