namespace Blogging.Domain.Base;

public abstract class CommentBase<TId> : Entity<TId> 
    where TId: struct, IEquatable<TId>
{
    protected CommentBase(string text, string commentedBy)
    {
        CommentedBy = Guard.Against.NullOrWhiteSpace(commentedBy, nameof(commentedBy));
        UpdateText(text);
    }

    public string Text { get; private set; } = default!;
    public string CommentedBy { get; private set; } = default!;
    public DateTime CommentedOn { get; private set; } = DateTime.UtcNow;
    public DateTime? LastUpdatedOn { get; private set; }

    public void UpdateText(string text)
    {
        Text = Guard.Against.NullOrWhiteSpace(text, nameof(text));
    }
}
