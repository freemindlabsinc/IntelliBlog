namespace Blogging.Domain.Aggregates.Blogs.Events;
public readonly record struct BlogUpdatedEvent(Blog Sender, string Property) : INotification;
