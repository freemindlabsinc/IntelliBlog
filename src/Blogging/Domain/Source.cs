namespace Blogging.Domain;

public class Source : TrackedEntity<int>, IAggregateRoot
{
    public Source(
        int blogId,
        string name,
        string? url = default,
        string? description = default)
    {
        BlogId = blogId; // Once-setter
        UpdateName(name);
        UpdateURL(url);
        UpdateDescription(description);        
    }

    public int BlogId { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public string? Description { get; private set; } = default!;
    public string? Url { get; private set; } = default!;

    public HashSet<string> Tags { get; private set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    public void AddTag(string tag)
    {
        Guard.Against.NullOrWhiteSpace(tag, nameof(tag));

        if (Tags.Add(tag)) RaiseEvent(new Events.SourceUpdated(this, nameof(Tags)));
    }

    public void RemoveTag(string tag)
    {
        Guard.Against.NullOrWhiteSpace(tag, nameof(tag));

        if (Tags.Remove(tag)) RaiseEvent(new Events.SourceUpdated(this, nameof(Tags)));
    }

    public void UpdateName(string name)
    {
        if (Name == name) return;

        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));

        RaiseEvent(new Events.SourceUpdated(this, nameof(Name)));
    }

    public void UpdateURL(string? url)
    {
        if (Url == url) return;

        Url = url;

        RaiseEvent(new Events.SourceUpdated(this, nameof(Url)));
    }

    public void UpdateDescription(string? description)
    {
        if (Description == description) return;

        Description = description;

        RaiseEvent(new Events.SourceUpdated(this, nameof(Description)));
    }

    // For Entity Framework
    private Source() { }
}
