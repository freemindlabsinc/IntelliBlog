namespace IntelliBlog.Domain.Articles;

public static class ArticleExtensions
{
    public static Article AddTags(this Article article, params string[] tags)
    {
        foreach (var tag in tags)
        {
            article.AddTag(tag);
        }        

        return article;
    }    
}
