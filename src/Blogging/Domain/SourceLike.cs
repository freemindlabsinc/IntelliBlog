namespace Blogging.Domain;

public class SourceLike : Entity<int>
{
    internal SourceLike(int sourceId, string likedBy)
    {
        SourceId = sourceId; // Once-setter
        LikedBy = Guard.Against.NullOrEmpty(likedBy, nameof(likedBy)); // Once-setter
    }

    public int SourceId { get; private set; } = default!;
    public string LikedBy { get; private set; } = default!;
    public DateTime LikedOn { get; private set; } = DateTime.UtcNow;
}
