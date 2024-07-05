using IntelliBlog.Application.Interfaces;
using IntelliBlog.Application.UseCases.Articles.Events;
using IntelliBlog.Domain.Aggregates.Articles;
using Microsoft.Extensions.Logging;

namespace IntelliBlog.Application.Services;

public class ArticleDeleteService(IUnitOfWork _unitOfWork,
  IMediator _mediator,
  ILogger<ArticleDeleteService> _logger) : IArticleDeleteService
{
    public async Task<Result> DeleteArticle(ArticleId articleId)
    {
        _logger.LogInformation("Deleting Article {articleId}", articleId);

        Article? aggregateToDelete = await _unitOfWork.ArticleRepository.GetByIdAsync(articleId);
        if (aggregateToDelete == null) return Result.NotFound();

        await _unitOfWork.ArticleRepository.DeleteAsync(aggregateToDelete);       

        var domainEvent = new ArticleDeletedEvent(articleId);

        await _mediator.Publish(domainEvent);

        return Result.Success();
    }


}
