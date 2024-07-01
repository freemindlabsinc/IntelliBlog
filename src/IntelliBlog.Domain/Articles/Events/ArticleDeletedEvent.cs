using Ardalis.SharedKernel;

namespace IntelliBlog.Domain.Articles.Events;

public sealed class ArticleDeletedEvent(ArticleId articleId) : DomainEventBase
{
    public ArticleId ArticleId { get; init; } = articleId;
}
