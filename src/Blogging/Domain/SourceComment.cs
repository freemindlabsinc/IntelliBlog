namespace Blogging.Domain;

public sealed class SourceComment : CommentBase<int>, IAggregateRoot
{
    public SourceComment(
        int sourceId,
        string text,
        string commentedBy)
        : base(text, commentedBy)
    {
        SourceId = sourceId; // Once-setter        
    }

    public int SourceId { get; private set; } = default!;
    
    // For Entity Framework
    //private SourceComment() : base() { }
}
