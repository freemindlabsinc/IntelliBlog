namespace Blogging.Domain.Aggregates.Articles;

public sealed class ArticleComment : CommentBase
{
    internal static ArticleComment CreateNew(        
        int articleId,
        string text,
        string commentedBy)
    {
        var comment = new ArticleComment();
        comment.ArticleId = articleId; // Once-setter        
        comment.UpdateText(text);
        comment.UpdateCommentedBy(commentedBy);

        return comment;
    }

    public int ArticleId { get; private set; } = default!;   

    // For Entity Framework
    private ArticleComment() { }
}
