namespace IntelliBlog.Domain.Aggregates.Sources;

public class Source : TrackedEntity<SourceId>, IAggregateRoot
{
    public static Source CreateNew(
        BlogId blogId,
        string name,
        string? url = default,
        string? description = default,
        SourceId id = default)
    {
        var source = new Source();
        source.Id = id; // Once-setter
        source.BlogId = blogId; // Once-setter
        source.UpdateName(name);
        source.UpdateURL(url);
        source.UpdateDescription(description);
        return source;
    }

    public BlogId BlogId { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public string? Description { get; private set; } = default!;
    public string? Url { get; private set; } = default!;

    public IReadOnlyCollection<SourceTag> Tags => _tags.AsReadOnly();

    public void UpdateName(string name)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
    }

    public void UpdateURL(string? url)
    {
        Url = url;
    }

    public void UpdateDescription(string? description)
    {
        Description = description;
    }

    public void AddTag(string name, string? description = default)
    {
        var tag = SourceTag.CreateNew(name, description);
        _tags.Add(tag);
    }

    public void RemoveTag(SourceTag tag)
    {
        _tags.Remove(tag);
    }

    private readonly List<SourceTag> _tags = new List<SourceTag>();

    // For Entity Framework
    private Source() { }
}
