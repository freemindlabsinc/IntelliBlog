using Ardalis.Result;
using FreeMindLabs.IntelliBlog.Core.Domain.Article;

namespace FreeMindLabs.IntelliBlog.Core.Interfaces;

public interface IArticleDeleteService
{
    public Task<Result> DeleteArticle(ArticleId id);
}
