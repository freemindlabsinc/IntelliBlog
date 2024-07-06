using IntelliBlog.Application.Interfaces;
using IntelliBlog.Domain.Aggregates.Articles;
using IntelliBlog.Domain.Aggregates.Blogs;
using IntelliBlog.Domain.Aggregates.Sources;

namespace IntelliBlog.Infrastructure.Data;
public class UnitOfWork(AppDbContext _dbContext) : IUnitOfWork
{
    Dictionary<Type, object> _repositories = new();

    public IRepository<Blog> BlogRepository => GetRepository<Blog>();

    public IRepository<Article> ArticleRepository => GetRepository<Article>();

    public IRepository<Source> SourceRepository => GetRepository<Source>();

    public Task<int> CompleteAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    public IRepository<TAGGREGATE> GetRepository<TAGGREGATE>()
        where TAGGREGATE : class, IAggregateRoot
    {
        if (_repositories.TryGetValue(typeof(TAGGREGATE), out var repo))
        {
            return (IRepository<TAGGREGATE>)repo;
        }

        var repositoryType = typeof(EfRepository<>);
        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TAGGREGATE)), _dbContext);
        if (repositoryInstance == null)
        {
            throw new InvalidOperationException($"Could not create repository of type {repositoryType.MakeGenericType(typeof(TAGGREGATE))}");
        }

        _repositories.Add(typeof(TAGGREGATE), repositoryInstance);
        
        return (IRepository<TAGGREGATE>)repositoryInstance;
    }
}
