using IntelliBlog.Application.Interfaces;
using IntelliBlog.Domain;

namespace IntelliBlog.Infrastructure.Data;
public class UnitOfWork(
    AppDbContext _dbContext,
    IMediator _mediator) 
    : IUnitOfWork
{
    Dictionary<Type, object> _repositories = new();

    public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
    {        
        var entityEvents = _dbContext.ChangeTracker
            .Entries<HasDomainEvents>()
            .Where(e => e.Entity.DomainEvents.Any())
            .SelectMany(e => e.Entity.DomainEvents)
            .ToArray();

        foreach (var evt in entityEvents)
        {
            await _mediator.Publish(evt, cancellationToken);
        }

        var changes = await _dbContext.SaveChangesAsync(cancellationToken);
        return changes;
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
