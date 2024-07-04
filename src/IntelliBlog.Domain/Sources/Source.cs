using IntelliBlog.Domain.Articles;

namespace IntelliBlog.Domain.Sources;

public class Source : TrackedEntity<SourceId>, IAggregateRoot
{
    public static Source CreateNew(
        BlogId blogId,
        string name,
        string? url = default,
        string? description = default)
    { 
        var source = new Source();
        source.UpdateName(name);
        source.UpdateURL(url);
        source.UpdateDescription(description);

        source.BlogId = blogId; // Once-setter

        return source;
    }

    public BlogId BlogId { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public string? Description { get; private set; } = default!;
    public string? URL { get; private set; } = default!;
    
    public IReadOnlyCollection<SourceTag> Tags => _tags.AsReadOnly();
    //public IReadOnlyCollection<ArticleSource> Articles => _articles.AsReadOnly();

    public void UpdateName(string name)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));        
    }

    public void UpdateURL(string? url)
    {
        URL = url;        
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
    //private readonly List<ArticleSource> _articles = new List<ArticleSource>();

    // For Entity Framework
    private Source() { }
}
