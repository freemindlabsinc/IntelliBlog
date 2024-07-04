namespace IntelliBlog.Domain.Articles;

public sealed class Article : TrackedEntity<ArticleId>, IAggregateRoot
{
    public static Article CreateNew(
        BlogId blogId,
        string title,
        string? description = default,
        string? text = default,
        ArticleId id = default)
    {
        var article = new Article();
        article.Id = id; // Once-setter 
        article.BlogId = blogId; // Once-setter
        article.UpdateTitle(title);
        article.UpdateDescription(description);
        article.UpdateText(text);
                
        return article;
    }

    public BlogId BlogId { get; private set; } = default!;
    public string Title { get; private set; } = default!;
    public string? Description { get; private set; }
    public string? Text { get; private set; }
    
    public IReadOnlyCollection<ArticleTag> Tags => _tags.AsReadOnly();
    public IReadOnlyCollection<ArticleSource> Sources => _sources.AsReadOnly();
    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();
    public IReadOnlyCollection<Like> Likes => _likes.AsReadOnly();

    public void UpdateTitle(string title)
    {
        Guard.Against.NullOrWhiteSpace(title, nameof(title));
        this.Title = title;                
    }

    public void UpdateDescription(string? description)
    {
        this.Description = description;        
    }

    public void UpdateText(string? text)
    {
        this.Text = text;        
    }

    public void AddTag(string name, string? description = default)
    {
        var tag = ArticleTag.CreateNew(name, description);
        _tags.Add(tag);        
    }

    public void AddSource(SourceId sourceId)
    { 
        var src = ArticleSource.CreateNew(this.Id, sourceId);
        _sources.Add(src);
    }

    public void RemoveSource(ArticleSource sourceId)
    { 
        _sources.Remove(sourceId);        
    }

    public void AddComment(string text, string commentedBy)
    {
        var comment = Comment.CreateNew(this.Id, text, commentedBy);
        _comments.Add(comment);
    }    

    public void RemoveComment(Comment comment)
    {
        _comments.Remove(comment);
    }

    public void Like(string likeUserId)
    {
        var like = _likes.FirstOrDefault(x => x.LikedBy == likeUserId);
        if (like != null)
            return;

        like = Articles.Like.CreateNew(this.Id, likeUserId);
        _likes.Add(like);
    }

    public void Unlike(string likeUserId)
    {
        var like = _likes.FirstOrDefault(x => x.LikedBy == likeUserId);
        if (like == null)
            return;

        _likes.Remove(like);
    }

    private readonly List<ArticleTag> _tags = new List<ArticleTag>();
    private readonly List<ArticleSource> _sources = new List<ArticleSource>();
    private readonly List<Comment> _comments = new List<Comment>();
    private readonly List<Like> _likes = new List<Like>();

    private Article() { } // For Entity Framework
}
