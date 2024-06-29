using Ardalis.Specification;

namespace FreeMindLabs.IntelliBlog.Core.ArticleAggregate.Specifications;

public class ArticleByIdSpec : Specification<Article>
{
  public ArticleByIdSpec(ArticleId articleId)
  {
    Query
        .Where(article => article.Id == articleId);
  }
}
