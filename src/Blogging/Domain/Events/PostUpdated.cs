namespace Blogging.Domain.Events;

public readonly record struct PostUpdated(Post Sender, string Property) : INotification;
