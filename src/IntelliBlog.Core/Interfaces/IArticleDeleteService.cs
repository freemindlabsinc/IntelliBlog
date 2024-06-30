using Ardalis.Result;
using IntelliBlog.Core.Domain.Article;

namespace IntelliBlog.Core.Interfaces;

public interface IArticleDeleteService
{
    public Task<Result> DeleteArticle(ArticleId id);
}
