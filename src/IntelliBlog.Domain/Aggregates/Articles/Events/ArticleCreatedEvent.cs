namespace IntelliBlog.Domain.Aggregates.Articles.Events;
public readonly record struct ArticleCreatedEvent(Article Sender) : INotification;
