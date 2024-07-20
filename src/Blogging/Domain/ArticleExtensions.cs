namespace Blogging.Domain;

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

    public static Article RemoveTags(this Article article, params string[] names)
    {
        foreach (var name in names)
        {
            article.RemoveTag(name);
        }

        return article;
    }

    public static Article AddSources(this Article article, params int[] sourcesIds)
    {
        foreach (var id in sourcesIds)
        {
            article.AddSource(id);
        }

        return article;
    }

    public static Article RemoveSources(this Article article, params int[] sourcesIds)
    {
        foreach (var id in sourcesIds)
        {
            var source = article.Sources.FirstOrDefault(s => s.SourceId == id);
            if (source != null)
            {
                article.RemoveSource(source);
            }
        }

        return article;
    }
}
