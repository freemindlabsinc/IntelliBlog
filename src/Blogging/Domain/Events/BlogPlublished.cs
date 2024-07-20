namespace Blogging.Domain.Events;

public readonly record struct BlogPlublished(Blog Sender) : INotification;
