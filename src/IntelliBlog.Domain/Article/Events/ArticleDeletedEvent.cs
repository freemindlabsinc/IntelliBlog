namespace IntelliBlog.Domain.Article.Events;

public sealed class ArticleDeletedEvent(ArticleId articleId) : DomainEventBase
{
    public ArticleId ArticleId { get; init; } = articleId;
}
