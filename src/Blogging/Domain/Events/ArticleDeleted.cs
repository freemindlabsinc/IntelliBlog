namespace Blogging.Domain.Events;

public readonly record struct ArticleDeleted(Article Sender) : INotification;
