using Blogging.Domain.Aggregates;
using Blogging.Domain.Aggregates.Articles;

namespace Blogging.Domain.Specifications;

public class ArticleByIdSpec : Specification<Article>, ISingleResultSpecification<Article>
{
    public ArticleByIdSpec(ArticleId articleId)
    {
        Query
            .Where(article => article.Id == articleId);
    }
}
