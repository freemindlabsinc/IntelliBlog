namespace Blogging.Domain.Aggregates.Articles;

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
            var tag = article.Tags.FirstOrDefault(t => t.Name == name);
            if (tag != null)
            {
                article.RemoveTag(tag.Id);
            }
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

    public static Article RemoveSources(this Article article, params SourceId[] sourcesIds)
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
