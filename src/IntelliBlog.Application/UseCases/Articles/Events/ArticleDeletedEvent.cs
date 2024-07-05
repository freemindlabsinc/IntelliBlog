namespace IntelliBlog.Application.UseCases.Articles.Events;

public sealed class ArticleDeletedEvent(ArticleId articleId) : DomainEventBase
{
    public ArticleId ArticleId { get; init; } = articleId;
}
