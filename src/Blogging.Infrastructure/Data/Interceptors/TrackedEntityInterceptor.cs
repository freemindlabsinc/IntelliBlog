
using System.Collections.Generic;
using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Blogging.Infrastructure.Data.Interceptors;
public class TrackedEntityInterceptor : SaveChangesInterceptor
{
    private readonly IUser _user;
    private readonly TimeProvider _dateTime;

    public TrackedEntityInterceptor(
        IUser user,
        TimeProvider dateTime)
    {
        _user = user;
        _dateTime = dateTime;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? context)
    {
        if (context == null) return;

        foreach (var entry in context.ChangeTracker.Entries<ITrackedEntity>())
        {
            var utcNow = _dateTime.GetUtcNow();
            var uid = _user.Id ?? string.Empty;

            // TODO: I am not entirely sure HasChangedOwnedEntities() plays any role or not in Added
            if (entry.State is EntityState.Added/* || entry.HasChangedOwnedEntities()*/)
            {
                entry.Entity.SetCreated(utcNow, uid);
            }
            else if (entry.State is EntityState.Modified || entry.HasChangedOwnedEntities())
            {
                entry.Entity.SetLastModified(utcNow, uid);
            }
        }
    }
}

internal static class EntityEntryExtensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry != null &&
            r.TargetEntry.Metadata.IsOwned() &&
            (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
}
