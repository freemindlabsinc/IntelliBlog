namespace Blogging.Domain.Events;
public readonly record struct BlogDeleted(Blog Sender) : INotification;
