namespace Blogging.Domain;

public class Source : TrackedEntity<int>, IAggregateRoot
{
    private readonly List<SourceLike> _likes = new List<SourceLike>();
    
    internal Source() { /* For Entity Framework/HotChocolate */ }

    public Source(
        int blogId,
        string name,
        string? url = default,
        string? description = default,
        string[]? tags = default)
    {
        this.BlogId = blogId; // Once-setter
        this.Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        this.Url = url;
        this.Description = description;
        this.Tags = tags?.ToArray() ?? Tags;
    }

    public int BlogId { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public SourceType Type { get; private set; } = SourceType.Unspecified;
    public string? Description { get; private set; } = default!;
    public string? Url { get; private set; } = default!;
    public string? Image { get; private set; }

    public IReadOnlyCollection<SourceLike> Likes => _likes.AsReadOnly();

    public string[] Tags { get; private set; } = Array.Empty<string>();

    public void AddTags(params string[] tags)
    {
        var goodTags = tags.Select(tag => Guard.Against.NullOrWhiteSpace(tag, nameof(tag)));

        Tags = Tags.Intersect(goodTags, StringComparer.OrdinalIgnoreCase)
                   .ToArray();

        RaiseEvent(new Events.SourceUpdated(this, nameof(Tags)));
    }

    public void RemoveTags(params string[] tags)
    {
        Tags = Tags.Except(tags, StringComparer.OrdinalIgnoreCase)
                   .ToArray();

        RaiseEvent(new Events.SourceUpdated(this, nameof(Tags)));
    }


    public void UpdateImage(string? image)
    {
        if (Image == image) return;

        Image = image;

        RaiseEvent(new Events.SourceUpdated(this, nameof(Image)));
    }

    public void SetType(SourceType type)
    {
        if (Type == type) return;

        Type = type;

        RaiseEvent(new Events.SourceUpdated(this, nameof(Type)));
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

    public void Like(string likedBy)
    {
        Guard.Against.NullOrWhiteSpace(likedBy, nameof(likedBy));

        if (_likes.Any(l => l.LikedBy == likedBy)) return;

        _likes.Add(new SourceLike(Id, likedBy));

        //RaiseEvent(new Events.SourceLiked(this, likedBy));
    }

    public void Unlike(string likedBy)
    {
        Guard.Against.NullOrWhiteSpace(likedBy, nameof(likedBy));

        var like = _likes.FirstOrDefault(l => l.LikedBy == likedBy);

        if (like is null) return;

        _likes.Remove(like);

        //RaiseEvent(new Events.SourceUnliked(this, likedBy));
    }


}
