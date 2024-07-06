namespace IntelliBlog.Application.UseCases.Blogs.Create;

public class BlogCreatedEvent(BlogId blogId) : INotification
{
    public BlogId BlogId { get; init; } = blogId;
}
