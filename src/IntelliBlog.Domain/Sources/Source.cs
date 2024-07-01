using IntelliBlog.Domain.Articles;

namespace IntelliBlog.Domain.Sources;

public readonly record struct SourceId(int Value)
{
    public static SourceId Empty { get; } = default;
    public override string ToString() => StrongIdHelper<SourceId, int>.Serialize(Value);
    public static SourceId? TryParse(string? value) => StrongIdHelper<SourceId, int>.Deserialize(value);
}


public class Source : TrackedEntity<SourceId>
{
    public static Source CreateNew(string name, string? url = default)
        => new Source(name).UpdateURL(url);

    public string Name { get; private set; } = default!;
    public string? URL { get; private set; } = default!;
    public string? Notes { get; private set; } = default!;

    public List<SourceTag> Tags { get; private set; } = new List<SourceTag>();    

    public Source UpdateName(string name)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));

        return this;
    }

    public Source UpdateURL(string? url)
    {
        URL = url;

        return this;
    }

    public Source UpdateNotes(string? notes)
    {
        Notes = notes;

        return this;
    }

    // For EF Core
    private Source(string name)
    {
        UpdateName(name);
    }
}
