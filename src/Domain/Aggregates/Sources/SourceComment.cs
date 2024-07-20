namespace Blogging.Domain.Aggregates.Sources;

public sealed class SourceComment : CommentBase
{
    internal static SourceComment CreateNew(
        int sourceId,
        string text,
        string commentedBy)
    {
        var comment = new SourceComment();
        comment.SourceId = sourceId; // Once-setter        
        comment.UpdateText(text);
        comment.UpdateCommentedBy(commentedBy);

        return comment;
    }

    public int SourceId { get; private set; } = default!;

    // For Entity Framework
    private SourceComment() { }
}
