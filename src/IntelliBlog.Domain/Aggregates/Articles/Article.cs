using IntelliBlog.Domain.Aggregates.Articles.Events;

namespace IntelliBlog.Domain.Aggregates.Articles;

public sealed class Article : TrackedEntity<ArticleId>, IAggregateRoot
{
    public static Article CreateNew(
        BlogId blogId,
        string title,
        string? description = default,
        string? text = default)
    {
        var article = new Article();
        article.BlogId = blogId; // Once-setter
        article.State = ArticleState.Draft;
        article.UpdateTitle(title);
        article.UpdateDescription(description);
        article.UpdateText(text);

        article.ClearDomainEvents();
        article.RegisterDomainEvent(new ArticleCreatedEvent(article));

        return article;
    }

    public BlogId BlogId { get; private set; } = default!;
    public string Title { get; private set; } = default!;
    public string? Description { get; private set; }
    public string? Text { get; private set; }
    public bool IsPublished { get; private set; }
    public ArticleState State { get; private set; }

    public IReadOnlyCollection<ArticleTag> Tags => _tags.AsReadOnly();
    public IReadOnlyCollection<ArticleSource> Sources => _sources.AsReadOnly();
    public IReadOnlyCollection<ArticleComment> Comments => _comments.AsReadOnly();
    public IReadOnlyCollection<ArticleLike> Likes => _likes.AsReadOnly();

    public void MarkDeleted()
    {
        RegisterDomainEvent(new ArticleDeletedEvent(this));
    }

    public void Publish()
    {
        if (this.IsPublished) return;

        IsPublished = true;

        RegisterDomainEvent(new ArticleUpdatedEvent(this, nameof(this.IsPublished)));
    }

    public void Unpublish()
    {
        if (!this.IsPublished) return;

        IsPublished = false;

        RegisterDomainEvent(new ArticleUpdatedEvent(this, nameof(this.IsPublished)));
    }

    public void SetIsComplete()
    {
        if (this.State == ArticleState.Complete) return;

        State = ArticleState.Complete;

        RegisterDomainEvent(new ArticleUpdatedEvent(this, nameof(this.State)));
    }

    public void SetIsDraft()
    {
        if (this.State == ArticleState.Draft) return;

        State = ArticleState.Draft;
        RegisterDomainEvent(new ArticleUpdatedEvent(this, nameof(this.State)));
    }

    public void UpdateTitle(string title)
    {
        if (this.Title == title) return;

        Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));        
        
        RegisterDomainEvent(new ArticleUpdatedEvent(this, nameof(Title)));
    }

    public void UpdateDescription(string? description)
    {
        if (this.Description == description) return;

        Description = description;

        RegisterDomainEvent(new ArticleUpdatedEvent(this, nameof(Description)));
    }

    public void UpdateText(string? text)
    {
        if (this.Text == text) return;

        Text = text;

        RegisterDomainEvent(new ArticleUpdatedEvent(this, nameof(Text)));
    }

    public void AddTag(string name, string? description = default)
    {
        var tag = ArticleTag.CreateNew(name, description);
        _tags.Add(tag);

        RegisterDomainEvent(new ArticleUpdatedEvent(this, nameof(Tags)));
    }

    public void RemoveTag(int tagId, string? description = default)
    {
        var tag = _tags.FirstOrDefault(t => t.Id == tagId);
        if (tag == null)
            return;

        _tags.Remove(tag);

        RegisterDomainEvent(new ArticleUpdatedEvent(this, nameof(Tags)));
    }

    public void AddSource(SourceId sourceId)
    {
        var src = ArticleSource.CreateNew(Id, sourceId);
        _sources.Add(src);

        RegisterDomainEvent(new ArticleUpdatedEvent(this, nameof(Sources)));
    }

    public void RemoveSource(ArticleSource sourceId)
    {
        _sources.Remove(sourceId);

        RegisterDomainEvent(new ArticleUpdatedEvent(this, nameof(Sources)));
    }

    public void AddComment(string text, string commentedBy)
    {
        var comment = ArticleComment.CreateNew(Id, text, commentedBy);
        _comments.Add(comment);

        RegisterDomainEvent(new ArticleUpdatedEvent(this, nameof(Comments)));
    }

    public void RemoveComment(ArticleComment comment)
    {
        _comments.Remove(comment);

        RegisterDomainEvent(new ArticleUpdatedEvent(this, nameof(Comments)));
    }

    public void Like(string likeUserId)
    {
        var like = _likes.FirstOrDefault(x => x.LikedBy == likeUserId);
        if (like != null)
            return;

        like = Articles.ArticleLike.CreateNew(Id, likeUserId);
        _likes.Add(like);

        RegisterDomainEvent(new ArticleUpdatedEvent(this, nameof(Likes)));
    }

    public void Unlike(string likeUserId)
    {
        var like = _likes.FirstOrDefault(x => x.LikedBy == likeUserId);
        if (like == null)
            return;

        _likes.Remove(like);

        RegisterDomainEvent(new ArticleUpdatedEvent(this, nameof(Likes)));
    }

    private readonly List<ArticleTag> _tags = new List<ArticleTag>();
    private readonly List<ArticleSource> _sources = new List<ArticleSource>();
    private readonly List<ArticleComment> _comments = new List<ArticleComment>();
    private readonly List<ArticleLike> _likes = new List<ArticleLike>();

    private Article() { } // For Entity Framework
}
