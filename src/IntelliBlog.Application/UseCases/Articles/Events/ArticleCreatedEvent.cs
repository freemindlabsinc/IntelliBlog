namespace IntelliBlog.Application.UseCases.Articles.Events;

public class ArticleCreatedEvent(ArticleId articleId) : DomainEventBase
{
    public ArticleId ArticleId { get; init; } = articleId;
}
