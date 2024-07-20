namespace Blogging.Domain.Events;

public readonly record struct BlogOnline(Blog Sender) : INotification;
