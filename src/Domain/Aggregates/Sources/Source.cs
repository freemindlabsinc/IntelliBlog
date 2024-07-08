using Blogging.Domain.Aggregates.Sources.Events;

namespace Blogging.Domain.Aggregates.Sources;

public class Source : TrackedEntity<SourceId>, IAggregateRoot
{
    public static Source CreateNew(
        BlogId blogId,
        string name,
        string? url = default,
        string? description = default)
    {
        var source = new Source();
        source.BlogId = blogId; // Once-setter
        source.UpdateName(name);
        source.UpdateURL(url);
        source.UpdateDescription(description);

        source.ClearDomainEvents();
        source.RegisterDomainEvent(new SourceCreatedEvent(source));

        return source;
    }

    public BlogId BlogId { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public string? Description { get; private set; } = default!;
    public string? Url { get; private set; } = default!;

    public IReadOnlyCollection<SourceTag> Tags => _tags.AsReadOnly();

    public void UpdateName(string name)
    {
        if (this.Name == name) return; 

        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));

        RegisterDomainEvent(new SourceUpdatedEvent(this, nameof(this.Name)));
    }

    public void UpdateURL(string? url)
    {
        if (this.Url == url) return;

        Url = url;

        RegisterDomainEvent(new SourceUpdatedEvent(this, nameof(this.Url)));
    }

    public void UpdateDescription(string? description)
    {
        if (this.Description == description) return;

        Description = description;

        RegisterDomainEvent(new SourceUpdatedEvent(this, nameof(this.Description)));
    }

    public void AddTag(string name, string? description = default)
    {
        var tag = SourceTag.CreateNew(name, description);
        _tags.Add(tag);

        RegisterDomainEvent(new SourceUpdatedEvent(this, nameof(this.Tags)));
    }

    public void RemoveTag(SourceTag tag)
    {
        _tags.Remove(tag);

        RegisterDomainEvent(new SourceUpdatedEvent(this, nameof(this.Tags)));
    }

    private readonly List<SourceTag> _tags = new List<SourceTag>();

    // For Entity Framework
    private Source() { }
}
