namespace Blogging.Domain.Events;

public readonly record struct ArticleUpdated(Article Sender, string Property) : INotification;
