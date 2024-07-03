namespace IntelliBlog.Domain.Sources;

public class Source : TrackedEntity<SourceId>, IAggregateRoot
{
    public static Source CreateNew(
        string name,
        string? url = default,
        string? description = default)
    { 
        var source = new Source();
        source.UpdateName(name);
        source.UpdateURL(url);
        source.UpdateDescription(description);

        return source;
    }

    public string Name { get; private set; } = default!;
    public string? Description { get; private set; } = default!;
    public string? URL { get; private set; } = default!;
    
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

    public Source UpdateDescription(string? description)
    {
        Description = description;

        return this;
    }

    // For Entity Framework
    private Source() { }
}
