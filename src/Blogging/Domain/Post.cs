namespace Blogging.Domain;

public sealed class Post : TrackedEntity<int>, IAggregateRoot
{
    private readonly List<PostSource> _sources = new List<PostSource>();
    private readonly List<PostLike> _likes = new List<PostLike>();
    
    internal Post() { /* For Entity Framework/HotChocolate */ }

    public Post(
        int blogId,
        string title,
        string? description = default,
        string? text = default,
        string[]? tags = default)
    {
        this.BlogId = blogId; // Once-setter
        this.State = PostState.Draft;
        this.Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
        this.Description = description;
        this.Text = text;
        this.Tags = tags?.ToArray() ?? Tags;
    }

    public int BlogId { get; private set; } = default!;
    public string Title { get; private set; } = default!;
    public string? Description { get; private set; }
    public string? Text { get; private set; }
    public bool IsPublished { get; private set; }
    public PostState State { get; private set; }
    public string? Image { get; private set; }

    public string[] Tags { get; private set; } = Array.Empty<string>();

    public IReadOnlyCollection<PostSource> Sources => _sources.AsReadOnly();    
    public IReadOnlyCollection<PostLike> Likes => _likes.AsReadOnly();

    public void Publish()
    {
        if (this.IsPublished) return;

        IsPublished = true;

        RaiseEvent(new Events.PostUpdated(this, nameof(this.IsPublished)));
    }

    public void Unpublish()
    {
        if (!this.IsPublished) return;

        IsPublished = false;

        RaiseEvent(new Events.PostUpdated(this, nameof(this.IsPublished)));
    }

    public void SetIsComplete()
    {
        if (this.State == PostState.Complete) return;

        State = PostState.Complete;

        RaiseEvent(new Events.PostUpdated(this, nameof(this.State)));
    }

    public void SetIsDraft()
    {
        if (this.State == PostState.Draft) return;

        State = PostState.Draft;
        RaiseEvent(new Events.PostUpdated(this, nameof(this.State)));
    }

    public void UpdateTitle(string title)
    {
        if (this.Title == title) return;

        Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));

        RaiseEvent(new Events.PostUpdated(this, nameof(Title)));
    }

    public void UpdateDescription(string? description)
    {
        if (this.Description == description) return;

        Description = description;

        RaiseEvent(new Events.PostUpdated(this, nameof(Description)));
    }

    public void UpdateText(string? text)
    {
        if (this.Text == text) return;

        Text = text;

        RaiseEvent(new Events.PostUpdated(this, nameof(Text)));
    }
    public void AddTags(params string[] tags)
    {
        var goodTags = tags.Select(tag => Guard.Against.NullOrWhiteSpace(tag, nameof(tag)));

        Tags = Tags.Union(goodTags)
                     .Distinct(StringComparer.OrdinalIgnoreCase)
                     .ToArray();

        RaiseEvent(new Events.PostUpdated(this, nameof(Tags)));
    }

    public void RemoveTags(params string[] tags)
    {
        Tags = Tags.Except(tags, StringComparer.OrdinalIgnoreCase)
                     .ToArray();

        RaiseEvent(new Events.PostUpdated(this, nameof(Tags)));
    }

    public void AddSources(params int[] sourceIds)
    {
        foreach (var sourceId in sourceIds)
        {
            var src = new PostSource(Id, sourceId);
            _sources.Add(src);
        }
        
        RaiseEvent(new Events.PostUpdated(this, nameof(Sources)));
    }

    public void RemoveSources(PostSource sourceId)
    {
        _sources.Remove(sourceId);

        RaiseEvent(new Events.PostUpdated(this, nameof(Sources)));
    }
   
    public void Like(string likeUserId)
    {
        var like = _likes.FirstOrDefault(x => x.LikedBy == likeUserId);
        if (like != null)
            return;

        like = new PostLike(Id, likeUserId);
        _likes.Add(like);

        RaiseEvent(new Events.PostUpdated(this, nameof(Likes)));
    }

    public void Unlike(string likeUserId)
    {
        var like = _likes.FirstOrDefault(x => x.LikedBy == likeUserId);
        if (like == null)
            return;

        _likes.Remove(like);

        RaiseEvent(new Events.PostUpdated(this, nameof(Likes)));
    }

    public void SetImage(string image)
    {
        if (this.Image == image) return;

        Image = Guard.Against.NullOrWhiteSpace(image, nameof(image));

        RaiseEvent(new Events.PostUpdated(this, nameof(Image)));
    }
}
