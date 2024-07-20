namespace Blogging.Domain.Base;

public abstract class CommentBase : Entity<int>
{
    protected CommentBase(string text, string commentedBy)
    {
        CommentedBy = Guard.Against.NullOrWhiteSpace(commentedBy, nameof(commentedBy));
        UpdateText(text);
    }

    public string Text { get; private set; } = default!;
    public string CommentedBy { get; private set; } = default!;

    public void UpdateText(string text)
    {        
        Text = Guard.Against.NullOrWhiteSpace(text, nameof(text));
    }    
}
