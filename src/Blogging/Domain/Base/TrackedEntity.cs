namespace Blogging.Domain.Base;

public abstract class TrackedEntity<TId>() : Entity<TId>, ITrackedEntity
    where TId : struct, IEquatable<TId>
{
    public DateTimeOffset CreatedOn { get; protected set; }

    public string? CreatedBy { get; protected set; }

    public DateTimeOffset? LastModifiedOn { get; protected set; }

    public string? LastModifiedBy { get; protected set; }

    void ITrackedEntity.SetCreated(DateTimeOffset createdOn, string createdBy)
    {
        CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
        CreatedOn = createdOn;

        // Resets the other properties
        LastModifiedBy = null;
        LastModifiedOn = null;
    }

    void ITrackedEntity.SetLastModified(DateTimeOffset lastModifiedOn, string lastModifiedBy)
    {
        if (CreatedOn == default || CreatedBy == null)
        {
            throw new InvalidOperationException($"{nameof(ITrackedEntity.SetCreated)} must be called before {nameof(ITrackedEntity.SetLastModified)}.");
        }
        
        LastModifiedBy = Guard.Against.NullOrEmpty(lastModifiedBy, nameof(lastModifiedBy));
        LastModifiedOn = lastModifiedOn;
    }
}
