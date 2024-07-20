namespace Blogging.Domain.Events;
public readonly record struct PostCreated(Post Sender) : INotification;
