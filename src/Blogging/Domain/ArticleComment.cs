namespace Blogging.Domain.Aggregates.Articles;

public sealed class ArticleComment : CommentBase<int>, IAggregateRoot
{
    public ArticleComment(        
        int articleId,
        string text,
        string commentedBy) : base(text, commentedBy)
    {
        ArticleId = articleId; // Once-setter                
    }

    public int ArticleId { get; private set; } = default!;

    public IReadOnlyCollection<ArticleCommentLike> Likes => _likes.AsReadOnly();

    public void Like(string likedBy)
    {
        if (_likes.Any(x => x.LikedBy == likedBy)) return;

        _likes.Add(new ArticleCommentLike(Id, likedBy));

        //RaiseEvent(new ArticleCommentLiked(this, likedBy));
    }

    public void Unlike(string likedBy)
    {
        var like = _likes.FirstOrDefault(x => x.LikedBy == likedBy);

        if (like is null) return;

        _likes.Remove(like);

        //RaiseEvent(new ArticleCommentUnliked(this, likedBy));
    }

    private readonly List<ArticleCommentLike> _likes = new List<ArticleCommentLike>();
    // For Entity Framework
    //private ArticleComment() { }
}
