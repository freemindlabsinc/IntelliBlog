namespace IntelliBlog.Domain.Articles;

public class ArticleTag : Tag
{
    internal static ArticleTag CreateNew(string name)
        => new ArticleTag(name);
    
    public Article Article { get; private set; } = default!;
    
    private ArticleTag(string name) 
        : base(name)
    {
    
    }
}
