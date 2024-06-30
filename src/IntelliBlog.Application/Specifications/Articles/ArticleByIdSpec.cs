using IntelliBlog.Domain.Article;

namespace IntelliBlog.Application.Specifications.Articles;

public class ArticleByIdSpec : Specification<Article>
{
    public ArticleByIdSpec(ArticleId articleId)
    {
        Query
            .Where(article => article.Id == articleId);
    }
}
