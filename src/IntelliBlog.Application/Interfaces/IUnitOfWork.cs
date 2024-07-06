using IntelliBlog.Domain.Aggregates.Articles;
using IntelliBlog.Domain.Aggregates.Blogs;
using IntelliBlog.Domain.Aggregates.Sources;

namespace IntelliBlog.Application.Interfaces;

// Insipired by https://medium.com/@josiahmahachi/how-to-use-iunitofwork-single-responsibility-principle-2821398addee
public interface IUnitOfWork
{
    public Task<int> CompleteAsync(CancellationToken cancellationToken = default);

    public IRepository<TAGGREGATE> GetRepository<TAGGREGATE>()
        where TAGGREGATE : class, IAggregateRoot;
}
