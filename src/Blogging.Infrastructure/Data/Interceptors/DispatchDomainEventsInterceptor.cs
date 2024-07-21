using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Blogging.Infrastructure.Data.Interceptors;

/// <summary>
/// This interceptor dispatches domain events after SaveChanges has been called.
/// It removes the need to have domain event logic inside BloggingDbContext.
/// </summary>
/// <remarks>
/// We could implement the Outbox pattern here.
/// </remarks>
public class DispatchDomainEventsInterceptor(
        IMediator _mediator,
        ILogger<DispatchDomainEventsInterceptor> _logger) 
    : SaveChangesInterceptor
{
    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();

        return base.SavedChanges(eventData, result);
    }

    public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        await DispatchDomainEvents(eventData.Context);

        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }    
    
    public async Task DispatchDomainEvents(DbContext? context)
    {
        if (context == null) return;

        var entities = context.ChangeTracker
            .Entries<IDomainEventContainer>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);
        
        var domainEvents = entities
            .SelectMany(e => e.DomainEvents)
            .ToList();

        entities.ToList().ForEach(e => e.ClearDomainEvents());

        _logger.LogInformation("Dispatching {Count} domain events. {Events}", 
            domainEvents.Count,
            domainEvents);

        foreach (var domainEvent in domainEvents)
            await _mediator.Publish(domainEvent);
    }
}
