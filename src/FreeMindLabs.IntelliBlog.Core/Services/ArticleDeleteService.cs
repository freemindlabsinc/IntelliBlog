using FreeMindLabs.IntelliBlog.Core.Domain.Article;
using FreeMindLabs.IntelliBlog.Core.Domain.Article.Events;
using FreeMindLabs.IntelliBlog.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FreeMindLabs.IntelliBlog.Core.Services;

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
