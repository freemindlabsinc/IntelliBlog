namespace IntelliBlog.Domain.Article;

public static class ArticleExtensions
{
    public static Article AddTags(this Article article, params string[] tags)
    {
        article.Tags.AddRange(tags.Select(tag => Tag.CreateNew(tag)));
        return article;
    }

    public static Article AddSources(this Article article, params string[] sources)
    {
        article.Sources.AddRange(sources.Select(src => Source.CreateNew(src)));

        return article;
    }

}
