namespace Blogging.Domain;

public sealed class PostSource : Entity<int>
{
    internal PostSource(int postId, int sourceId)
    {
        PostId = postId;
        SourceId = sourceId;        
    }

    //public int Id { get; private set; } = default!; // It's never accessed directly so it does not need to be a strong id
    public int PostId { get; private set; } = default!;
    public int SourceId { get; private set; } = default!;        
    public DateTime LinkedOn { get; private set; } = DateTime.UtcNow;
}
