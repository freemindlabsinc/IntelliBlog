namespace Blogging.Domain.Blogs;
public readonly record struct BlogCreatedEvent(Blog Sender) : INotification;
