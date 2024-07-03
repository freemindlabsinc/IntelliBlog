using IntelliBlog.Domain.Articles;

namespace IntelliBlog.Domain.Blogs;

public class BlogArticle : HasDomainEventsBase
{
    public static BlogArticle CreateNew(BlogId blogId, ArticleId articleId, int sequence)
    {
        var blogArticle = new BlogArticle();
        blogArticle.BlogId = blogId;
        blogArticle.ArticleId = articleId;
        blogArticle.Seq = sequence;
        return blogArticle;
    }

    public BlogId BlogId { get; private set; } = default!;
    public ArticleId ArticleId { get; private set; } = default!;
    public int Seq { get; private set; }
    public void IncrementSequence()
    {
        Seq++;
    }
}
