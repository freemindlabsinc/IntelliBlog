namespace IntelliBlog.Domain.Aggregates.Articles;

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

    public static Article AddSources(this Article article, params SourceId[] sourcesIds)
    {
        foreach (var id in sourcesIds)
        {
            article.AddSource(id);
        }

        return article;
    }
}
