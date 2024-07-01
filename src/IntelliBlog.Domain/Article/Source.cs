namespace IntelliBlog.Domain.Article;

public readonly record struct SourceId(int Value)
{
    public static SourceId Empty { get; } = default;
    public override string ToString() => StrongIdHelper<SourceId, int>.Serialize(Value);
    public static SourceId? TryParse(string? value) => StrongIdHelper<SourceId, int>.Deserialize(value);
}

public class Source : EntityBase<SourceId>
{
    public static Source CreateNew(string name)
    {
        return new Source(name);
    }

    public string Name { get; private set; } = default!;
    public string URL { get; private set; } = default!;

    // For EF Core
    private Source(string name)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name))
            .ToUpperInvariant(); // TODO: investigate on this type of uppercasing
    }
}
