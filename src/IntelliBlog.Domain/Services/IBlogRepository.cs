using IntelliBlog.Domain.Aggregates.Blogs;

namespace IntelliBlog.Domain.Services;
public interface IBlogRepository
{
    public Task<Blog> GetByIdAsync(BlogId blogId, CancellationToken cancellationToken = default);
    public Task<Blog> AddAsync(Blog blog, CancellationToken cancellationToken = default);
    public Task<Blog> DeleteAsync(Blog blog, CancellationToken cancellationToken = default);    
}
