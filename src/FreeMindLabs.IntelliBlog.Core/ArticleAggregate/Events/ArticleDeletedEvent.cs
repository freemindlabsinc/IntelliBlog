using Ardalis.SharedKernel;

namespace FreeMindLabs.IntelliBlog.Core.ArticleAggregate.Events;

internal sealed class ArticleDeletedEvent(ArticleId articleId) : DomainEventBase
{
    public ArticleId ArticleId { get; init; } = articleId;
}
