namespace IntelliBlog.Domain.Aggregates.Articles.Events;

public readonly record struct ArticleUpdatedEvent(Article Sender, string Property) : INotification;
