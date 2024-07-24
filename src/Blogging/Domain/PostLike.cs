namespace Blogging.Domain;

public sealed class PostLike : Entity<int> 
{
    internal PostLike(int postId, string likedBy)
    {
        PostId = postId; // Once-setter
        LikedBy = Guard.Against.NullOrEmpty(likedBy, nameof(likedBy)); // Once-setter
    }

    public int PostId { get; private set; } = default!;
    public string LikedBy { get; private set; } = default!; 
    public DateTime LikedOn { get; private set; } = DateTime.UtcNow;
}
