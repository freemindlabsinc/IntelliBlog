namespace Blogging.Domain.Aggregates.Blogs.Events;
public readonly record struct BlogDeletedEvent(Blog Sender) : INotification;
