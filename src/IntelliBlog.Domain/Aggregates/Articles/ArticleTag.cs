namespace IntelliBlog.Domain.Aggregates.Articles;

public class ArticleTag : Tag
{
    internal static ArticleTag CreateNew(string name, string? description = default)
    {
        var tag = new ArticleTag();
        tag.UpdateName(name);
        tag.UpdateDescription(description);
            
        return tag;
    }

    private ArticleTag() { } // For Entity Framework
}
