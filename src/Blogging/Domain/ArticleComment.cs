namespace Blogging.Domain.Aggregates.Articles;

public sealed class ArticleComment : CommentBase
{
    public ArticleComment(        
        int articleId,
        string text,
        string commentedBy) : base(text, commentedBy)
    {
        ArticleId = articleId; // Once-setter                
    }

    public int ArticleId { get; private set; } = default!;   

    // For Entity Framework
    //private ArticleComment() { }
}
