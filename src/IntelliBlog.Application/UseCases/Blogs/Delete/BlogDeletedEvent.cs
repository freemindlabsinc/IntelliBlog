namespace IntelliBlog.Application.UseCases.Blogs.Delete;
public class BlogDeletedEvent(BlogId blogId) : INotification
{
    public BlogId BlogId { get; init; } = blogId;
}
