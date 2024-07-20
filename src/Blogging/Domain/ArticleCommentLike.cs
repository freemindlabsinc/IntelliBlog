namespace Blogging.Domain.Aggregates.Articles;

public sealed class ArticleCommentLike : Entity<int>
{
    internal ArticleCommentLike(int articleCommentId, string likedBy)
    {
        ArticleCommentId = articleCommentId; // Once-setter
        LikedBy = Guard.Against.NullOrEmpty(likedBy, nameof(likedBy)); // Once-setter
    }

    public int ArticleCommentId { get; private set; } = default!;
    public string LikedBy { get; private set; } = default!;
    public DateTime LikedOn { get; private set; } = DateTime.UtcNow;
}
