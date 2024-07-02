using IntelliBlog.Domain.Sources;

namespace IntelliBlog.Domain.Articles;

public static class ArticleExtensions
{
    public static Article AddTags(this Article article, params string[] tags)
    {
        article.Tags.AddRange(tags.Select(tag => ArticleTag.CreateNew(tag)));
        return article;
    }

    //public static Article AddSources(this Article article, params SourceId[] sources)
    //{
    //    article.Sources.AddRange(sources.Select(src => Source.CreateNew(src)));
    //
    //    return article;
    //}

}
