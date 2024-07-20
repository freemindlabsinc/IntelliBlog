namespace Blogging.Domain.Events;

public readonly record struct BlogUnplublished(Blog Sender) : INotification;
