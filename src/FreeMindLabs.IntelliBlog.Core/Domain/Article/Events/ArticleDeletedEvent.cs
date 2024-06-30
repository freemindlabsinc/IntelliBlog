namespace FreeMindLabs.IntelliBlog.Core.Domain.Article.Events;

internal sealed class ArticleDeletedEvent(ArticleId articleId) : DomainEventBase
{
    public ArticleId ArticleId { get; init; } = articleId;
}
