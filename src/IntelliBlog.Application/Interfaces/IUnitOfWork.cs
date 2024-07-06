using IntelliBlog.Domain.Aggregates.Articles;
using IntelliBlog.Domain.Aggregates.Blogs;
using IntelliBlog.Domain.Aggregates.Sources;

namespace IntelliBlog.Application.Interfaces;
public interface IUnitOfWork
{
    public Task<int> CompleteAsync(CancellationToken cancellationToken = default);

    public IRepository<TAGGREGATE> GetRepository<TAGGREGATE>()
        where TAGGREGATE : class, IAggregateRoot, new();

    public IRepository<Blog> BlogRepository { get; }
    public IRepository<Article> ArticleRepository { get; }
    public IRepository<Source> SourceRepository { get; }
}
