namespace Blogging.Domain.Events;

public readonly record struct BlogOffline(Blog Sender) : INotification;
