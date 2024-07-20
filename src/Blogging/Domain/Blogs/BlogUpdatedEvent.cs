namespace Blogging.Domain.Blogs;
public readonly record struct BlogUpdatedEvent(Blog Sender, string Property) : INotification;
