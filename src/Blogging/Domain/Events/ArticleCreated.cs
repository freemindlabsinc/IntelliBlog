namespace Blogging.Domain.Events;
public readonly record struct ArticleCreated(Article Sender) : INotification;
