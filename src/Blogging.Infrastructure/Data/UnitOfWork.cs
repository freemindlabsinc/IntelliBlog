using Blogging.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Blogging.Infrastructure.Data;
public class UnitOfWork(
    BloggingDbContext _dbContext,
    IMediator _mediator,
    ILogger<UnitOfWork> _logger) 
    : IUnitOfWork
{
    private Func<Task<object>> _work = default!;
    public void Setup(Func<Task<object>> work)
    {
        _work = work;
    }

    public async Task<object> CompleteAsync(CancellationToken cancellationToken = default)
    {
        var strategy = _dbContext.Database.CreateExecutionStrategy();

        return await strategy.ExecuteAsync(async () =>
        {            
            Guid transactionId;

            await using var transaction = await _dbContext.Database.BeginTransactionAsync();

            using (_logger.BeginScope(new List<KeyValuePair<string, object>> { new("TransactionContext", transaction.TransactionId) }))
            {
                _logger.LogInformation("Begin transaction {TransactionId}", transaction.TransactionId);
                
                var response = await _work();

                // --------
                var entityEvents = _dbContext.ChangeTracker
                    .Entries<IDomainEventContainer>()
                    .Where(e => e.Entity.DomainEvents.Any())
                    .SelectMany(e => e.Entity.DomainEvents)
                    .ToArray();

                foreach (var evt in entityEvents)
                {
                    await _mediator.Publish(evt, cancellationToken);
                }

                var changes = await _dbContext.SaveChangesAsync(cancellationToken);
                // -------

                _logger.LogInformation("Commit transaction {TransactionId}", transaction.TransactionId);

                await _dbContext.Database.CommitTransactionAsync(cancellationToken);

                transactionId = transaction.TransactionId;

                return response;
            }           
        });
    }

    //public async Task<int> CompleteAsyncOLD(CancellationToken cancellationToken = default)
    //{        
    //    var entityEvents = _dbContext.ChangeTracker
    //        .Entries<IDomainEventContainer>()
    //        .Where(e => e.Entity.DomainEvents.Any())
    //        .SelectMany(e => e.Entity.DomainEvents)
    //        .ToArray();

    //    foreach (var evt in entityEvents)
    //    {
    //        await _mediator.Publish(evt, cancellationToken);
    //    }

    //    var changes = await _dbContext.SaveChangesAsync(cancellationToken);
    //    return changes;
    //}

    
}
