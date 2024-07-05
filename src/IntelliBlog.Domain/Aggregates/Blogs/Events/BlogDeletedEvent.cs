namespace IntelliBlog.Domain.Aggregates.Blogs.Events;
public class BlogDeletedEvent : DomainEventBase
{
    public BlogId BlogId { get; init; }

    public BlogDeletedEvent(BlogId blogId)
    {
        BlogId = blogId;
    }
}
