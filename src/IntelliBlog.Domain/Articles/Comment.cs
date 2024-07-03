namespace IntelliBlog.Domain.Articles;

public sealed class Comment : Entity<CommentId>
{
    public static Comment CreateNew(        
        string text,
        string commentedBy)
        //,CommentId parentId = default)
    {
        var comment = new Comment();
        //{
        //    ParentId = parentId,
        //};
        comment.UpdateText(text);
        
        return comment;
    }

    public ArticleId ArticleId { get; private set; } = default!;
    public string Text { get; private set; } = default!;
    public string CommentedBy { get; private set; } = default!;
   // public CommentId? ParentId { get; private set; }

    public Comment UpdateText(string text)
    {
        Guard.Against.NullOrWhiteSpace(text, nameof(text));
        Text = text;
        return this;
    }
    
    // For Entity Framework
    private Comment() { }
}
