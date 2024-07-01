namespace IntelliBlog.Domain.Article;

public readonly record struct TagId(int Value)
{
    public static TagId Empty { get; } = default;
    public override string ToString() => StrongIdHelper<TagId, int>.Serialize(Value);
    public static TagId? TryParse(string? value) => StrongIdHelper<TagId, int>.Deserialize(value);
}

public class Tag : EntityBase<TagId>
{
    public static Tag CreateNew(string name)
    {
        return new Tag(name);
    }

    public static IEnumerable<Tag> CreateMany(IEnumerable<string> names)
    { 
        return names.Select(name => new Tag(name));
    }

    public string Name { get; private set; } = default!;

    private Tag(string name)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name))
            .ToUpperInvariant(); // TODO: investigate on this type of uppercasing
    }
}
