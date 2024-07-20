namespace Blogging.Domain.Events;
public readonly record struct BlogCreated(Blog Sender) : INotification;
