namespace FreeMindLabs.IntelliBlog.Core.Domain.Article.Specifications;

public class ArticleByIdSpec : Specification<Article>
{
    public ArticleByIdSpec(ArticleId articleId)
    {
        Query
            .Where(article => article.Id == articleId);
    }
}
