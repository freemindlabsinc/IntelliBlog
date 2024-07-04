namespace IntelliBlog.Domain.Blogs;

public class BlogArticle : HasDomainEventsBase
{
    public static BlogArticle CreateNew(BlogId blogId, ArticleId articleId)
    {
        var blogArticle = new BlogArticle();
        blogArticle.BlogId = blogId;
        blogArticle.ArticleId = articleId;
        return blogArticle;
    }

    public BlogId BlogId { get; private set; } = default!;
    public ArticleId ArticleId { get; private set; } = default!;    
}
