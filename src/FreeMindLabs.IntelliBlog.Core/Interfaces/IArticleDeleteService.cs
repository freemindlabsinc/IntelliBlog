using Ardalis.Result;
using FreeMindLabs.IntelliBlog.Core.ArticleAggregate;

namespace FreeMindLabs.IntelliBlog.Core.Interfaces;

public interface IArticleDeleteService
{
    public Task<Result> DeleteArticle(ArticleId id);
}
