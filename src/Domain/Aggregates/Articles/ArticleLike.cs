namespace Blogging.Domain.Aggregates.Articles;

public sealed class ArticleLike : Entity<int> 
{
    internal static ArticleLike CreateNew(int articleId, string likedBy)
    {
        var like = new ArticleLike();
        like.ArticleId = articleId; // Once-setter
        like.UpdateLikedBy(likedBy);
        return like;
    }

    public int ArticleId { get; private set; } = default!;
    public string LikedBy { get; private set; } = default!; 

    public void UpdateLikedBy(string likedBy)
    {
        Guard.Against.NullOrWhiteSpace(likedBy, nameof(likedBy));
        
        LikedBy = likedBy;
    }

    // For Entity Framework
    private ArticleLike() { }
}
