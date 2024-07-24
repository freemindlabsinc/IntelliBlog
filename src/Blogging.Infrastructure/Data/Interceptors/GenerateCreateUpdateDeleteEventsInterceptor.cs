using Blogging.Domain.Events;
using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Blogging.Infrastructure.Data.Interceptors;

public class GenerateCreateUpdateDeleteEventsInterceptor(
        IMediator _mediator,
        ILogger<DispatchDomainEventsInterceptor> _logger
    )
    : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        GenerateAppropriateEvents(eventData.Context).GetAwaiter().GetResult(); 

        return base.SavingChanges(eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await GenerateAppropriateEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }


    public async Task GenerateAppropriateEvents(DbContext? context)
    {
        if (context == null) return;

        var allUpdates = context.ChangeTracker
            .Entries<IAggregateRoot>()
            .Where(e => e.State != EntityState.Unchanged && e.State != EntityState.Detached);

        foreach (var entry in allUpdates)
        {
            switch (entry.State)
            {
                case EntityState.Deleted:
                    var evtType = typeof(EntityDeletedEvent<>).MakeGenericType(entry.Entity.GetType());
                    var evt = (INotification)Activator.CreateInstance(evtType, entry.Entity)!;
                    _logger.LogInformation("EntityDeletedEvent: {Entity}", entry.Entity);

                    await _mediator.Publish(evt);

                    break;
                case EntityState.Modified:
                    var evtType2 = typeof(EntityUpdatedEvent<>).MakeGenericType(entry.Entity.GetType());
                    var evt2 = (INotification)Activator.CreateInstance(evtType2, entry.Entity)!;
                    _logger.LogInformation("EntityUpdatedEvent: {Entity}", entry.Entity);

                    await _mediator.Publish(evt2);
                    break;
                case EntityState.Added:
                    var evtType3 = typeof(EntityCreatedEvent<>).MakeGenericType(entry.Entity.GetType());
                    var evt3 = (INotification)Activator.CreateInstance(evtType3, entry.Entity)!;
                    _logger.LogInformation("EntityCreatedEvent: {Entity}", entry.Entity);

                    await _mediator.Publish(evt3);
                    break;
                default:
                    break;
            }
        }        
    }
}
