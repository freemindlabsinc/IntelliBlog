namespace IntelliBlog.Domain.Articles;

public sealed class Comment : Entity<CommentId>
{
    internal static Comment CreateNew(        
        ArticleId articleId,
        string text,
        string commentedBy)
        //,CommentId parentId = default)
    {
        var comment = new Comment();
        comment.ArticleId = articleId; // Once-setter        
        comment.UpdateText(text);
        comment.UpdateCommentedBy(commentedBy);

        return comment;
    }

    public ArticleId ArticleId { get; private set; } = default!;
    public string Text { get; private set; } = default!;
    public string CommentedBy { get; private set; } = default!;
    // public CommentId? ParentId { get; private set; }

    public void UpdateText(string text)
    {
        Guard.Against.NullOrWhiteSpace(text, nameof(text));
        Text = text;     
    }

    public void UpdateCommentedBy(string commentedBy)
    {
        Guard.Against.NullOrWhiteSpace(commentedBy, nameof(commentedBy));
        CommentedBy = commentedBy;
    }

    // For Entity Framework
    private Comment() { }
}
