namespace Blogging.Domain;

public sealed class Article : TrackedEntity<int>, IAggregateRoot
{
    public Article(
        int blogId,
        string title,
        string? description = default,
        string? text = default)
    {
        BlogId = blogId; // Once-setter
        State = ArticleState.Draft;
        UpdateTitle(title);
        UpdateDescription(description);
        UpdateText(text);        
    }

    public int BlogId { get; private set; } = default!;
    public string Title { get; private set; } = default!;
    public string? Description { get; private set; }
    public string? Text { get; private set; }
    public bool IsPublished { get; private set; }
    public ArticleState State { get; private set; }

    public ISet<string> Tags { get; private set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    public IReadOnlyCollection<ArticleSource> Sources => _sources.AsReadOnly();    
    public IReadOnlyCollection<ArticleLike> Likes => _likes.AsReadOnly();

    public void Publish()
    {
        if (this.IsPublished) return;

        IsPublished = true;

        RaiseEvent(new Events.ArticleUpdated(this, nameof(this.IsPublished)));
    }

    public void Unpublish()
    {
        if (!this.IsPublished) return;

        IsPublished = false;

        RaiseEvent(new Events.ArticleUpdated(this, nameof(this.IsPublished)));
    }

    public void SetIsComplete()
    {
        if (this.State == ArticleState.Complete) return;

        State = ArticleState.Complete;

        RaiseEvent(new Events.ArticleUpdated(this, nameof(this.State)));
    }

    public void SetIsDraft()
    {
        if (this.State == ArticleState.Draft) return;

        State = ArticleState.Draft;
        RaiseEvent(new Events.ArticleUpdated(this, nameof(this.State)));
    }

    public void UpdateTitle(string title)
    {
        if (this.Title == title) return;

        Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));

        RaiseEvent(new Events.ArticleUpdated(this, nameof(Title)));
    }

    public void UpdateDescription(string? description)
    {
        if (this.Description == description) return;

        Description = description;

        RaiseEvent(new Events.ArticleUpdated(this, nameof(Description)));
    }

    public void UpdateText(string? text)
    {
        if (this.Text == text) return;

        Text = text;

        RaiseEvent(new Events.ArticleUpdated(this, nameof(Text)));
    }    
    public void AddTags(params string[] tags)
    {
        var goodTags = tags.Select(tag => Guard.Against.NullOrWhiteSpace(tag, nameof(tag)));

        foreach (var item in goodTags)
        {
            Tags.Add(item);
        }

        RaiseEvent(new Events.ArticleUpdated(this, nameof(Tags)));
    }

    public void RemoveTags(params string[] tags)
    {
        foreach (var tag in tags)
        {
            Tags.Remove(tag);
        }
        
        RaiseEvent(new Events.ArticleUpdated(this, nameof(Tags)));
    }

    public void AddSources(params int[] sourceIds)
    {
        foreach (var sourceId in sourceIds)
        {
            var src = new ArticleSource(Id, sourceId);
            _sources.Add(src);
        }
        
        RaiseEvent(new Events.ArticleUpdated(this, nameof(Sources)));
    }

    public void RemoveSources(ArticleSource sourceId)
    {
        _sources.Remove(sourceId);

        RaiseEvent(new Events.ArticleUpdated(this, nameof(Sources)));
    }
   
    public void Like(string likeUserId)
    {
        var like = _likes.FirstOrDefault(x => x.LikedBy == likeUserId);
        if (like != null)
            return;

        like = new ArticleLike(Id, likeUserId);
        _likes.Add(like);

        RaiseEvent(new Events.ArticleUpdated(this, nameof(Likes)));
    }

    public void Unlike(string likeUserId)
    {
        var like = _likes.FirstOrDefault(x => x.LikedBy == likeUserId);
        if (like == null)
            return;

        _likes.Remove(like);

        RaiseEvent(new Events.ArticleUpdated(this, nameof(Likes)));
    }

    private readonly List<ArticleSource> _sources = new List<ArticleSource>();
    private readonly List<ArticleLike> _likes = new List<ArticleLike>();

    private Article() { } // For Entity Framework
}
