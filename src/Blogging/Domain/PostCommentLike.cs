namespace Blogging.Domain;

public sealed class PostCommentLike : Entity<int>
{
    internal PostCommentLike(int postCommentId, string likedBy)
    {
        PostCommentId = postCommentId; // Once-setter
        LikedBy = Guard.Against.NullOrEmpty(likedBy, nameof(likedBy)); // Once-setter
    }

    public int PostCommentId { get; private set; } = default!;
    public string LikedBy { get; private set; } = default!;
    public DateTime LikedOn { get; private set; } = DateTime.UtcNow;
}
