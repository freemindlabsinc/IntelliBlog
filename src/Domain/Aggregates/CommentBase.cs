namespace Blogging.Domain.Aggregates;

public abstract class CommentBase : Entity<int>
{
    public string Text { get; private set; } = default!;
    public string CommentedBy { get; private set; } = default!;

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
}
