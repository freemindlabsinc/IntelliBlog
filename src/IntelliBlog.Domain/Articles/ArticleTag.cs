namespace IntelliBlog.Domain.Articles;

public class ArticleTag : Entity<TagId>
{
    internal static ArticleTag CreateNew(string name)
        => new ArticleTag(name);
    
    public Article Article { get; private set; } = default!;
    public string Name { get; private set; } = default!;

    private ArticleTag(string name)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
    }
}
