namespace Blogging.Domain.Events;

public readonly record struct PostDeleted(Post Sender) : INotification;
