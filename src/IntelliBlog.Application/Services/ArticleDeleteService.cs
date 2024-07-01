using IntelliBlog.Application.Interfaces;
using IntelliBlog.Domain.Articles;
using IntelliBlog.Domain.Articles.Events;
using Microsoft.Extensions.Logging;

namespace IntelliBlog.Application.Services;

public class ArticleDeleteService(IRepository<Article> _repository,
  IMediator _mediator,
  ILogger<ArticleDeleteService> _logger) : IArticleDeleteService
{
    public async Task<Result> DeleteArticle(ArticleId articleId)
    {
        _logger.LogInformation("Deleting Article {articleId}", articleId);
        Article? aggregateToDelete = await _repository.GetByIdAsync(articleId);
        if (aggregateToDelete == null) return Result.NotFound();

        await _repository.DeleteAsync(aggregateToDelete);
        var domainEvent = new ArticleDeletedEvent(articleId);
        await _mediator.Publish(domainEvent);
        return Result.Success();
    }


}
