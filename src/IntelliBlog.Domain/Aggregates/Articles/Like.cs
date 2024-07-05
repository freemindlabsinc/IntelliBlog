namespace IntelliBlog.Domain.Aggregates.Articles;

public sealed class Like : Entity<int> 
{
    internal static Like CreateNew(ArticleId articleId, string likedBy)
    {
        var like = new Like();
        like.ArticleId = articleId; // Once-setter
        like.UpdateLikedBy(likedBy);
        return like;
    }

    public ArticleId ArticleId { get; private set; } = default!;
    public string LikedBy { get; private set; } = default!; 

    public void UpdateLikedBy(string likedBy)
    {
        Guard.Against.NullOrWhiteSpace(likedBy, nameof(likedBy));
        
        LikedBy = likedBy;
    }

    // For Entity Framework
    private Like() { }
}
