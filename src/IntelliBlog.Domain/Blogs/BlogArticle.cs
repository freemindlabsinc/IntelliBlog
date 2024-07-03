using IntelliBlog.Domain.Articles;

namespace IntelliBlog.Domain.Blogs;

public class BlogArticle : Entity<int>
{
    public static BlogArticle CreateNew(Blog blog, Article article, int order)
    {
        var blogArticle = new BlogArticle();
        blogArticle.Blog = blog;
        blogArticle.Article = article;
        blogArticle.Order = order;
        return blogArticle;
    }

    public Blog Blog { get; private set; } = default!;
    public Article Article { get; private set; } = default!;
    public int Order { get; private set; }    
}
