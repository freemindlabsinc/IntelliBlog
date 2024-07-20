namespace Blogging.Domain;

public sealed class ArticleLike : Entity<int> 
{
    internal ArticleLike(int articleId, string likedBy)
    {
        ArticleId = articleId; // Once-setter
        LikedBy = Guard.Against.NullOrEmpty(LikedBy, nameof(likedBy)); // Once-setter
    }

    public int ArticleId { get; private set; } = default!;
    public string LikedBy { get; private set; } = default!; 
    public DateTime LikedOn { get; private set; } = DateTime.UtcNow;
}
