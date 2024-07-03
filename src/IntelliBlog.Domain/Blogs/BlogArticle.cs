using IntelliBlog.Domain.Articles;

namespace IntelliBlog.Domain.Blogs;

public class BlogArticle : Entity<int>
{
    public static BlogArticle CreateNew(BlogId blogId, ArticleId articleId, int order)
    {
        var blogArticle = new BlogArticle();
        blogArticle.BlogId = blogId;
        blogArticle.ArticleId = articleId;
        blogArticle.Seq = order;
        return blogArticle;
    }

    public BlogId BlogId { get; private set; } = default!;
    public ArticleId ArticleId { get; private set; } = default!;
    public int Seq { get; private set; }    
}
