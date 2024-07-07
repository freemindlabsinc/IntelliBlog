namespace IntelliBlog.Domain.Aggregates.Blogs.Events;
public readonly record struct BlogDeletedEvent(Blog Sender) : INotification;
