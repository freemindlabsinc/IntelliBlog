namespace Blogging.Domain.Blogs;
public readonly record struct BlogDeletedEvent(Blog Sender) : INotification;
