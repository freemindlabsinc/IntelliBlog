using Ardalis.Result;
using IntelliBlog.Domain;

namespace IntelliBlog.Application.Interfaces;

public interface IArticleDeleteService
{
    public Task<Result> DeleteArticle(ArticleId id);
}
