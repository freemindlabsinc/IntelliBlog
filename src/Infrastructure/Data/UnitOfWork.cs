using Blogging.Domain.Services;

namespace Blogging.Infrastructure.Data;
public class UnitOfWork(
    AppDbContext _dbContext,
    IMediator _mediator) 
    : IUnitOfWork
{
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
}
