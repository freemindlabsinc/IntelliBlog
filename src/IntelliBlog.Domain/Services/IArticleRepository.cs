using IntelliBlog.Domain.Aggregates.Articles;

namespace IntelliBlog.Domain.Services;

public interface IArticleRepository
{
    public Task<Article> GetByIdAsync(ArticleId articleId, CancellationToken cancellationToken = default);
    public Task<Article> AddAsync(Article article, CancellationToken cancellationToken = default);
    public Task<Article> DeleteAsync(Article article, CancellationToken cancellationToken = default);
}
