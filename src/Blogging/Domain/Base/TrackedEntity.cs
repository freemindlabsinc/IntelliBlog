namespace Blogging.Domain.Base;

public abstract class TrackedEntity<TId>() : Entity<TId>
    where TId : struct, IEquatable<TId>
{
    public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

    public string? CreatedBy { get; private set; } = default!;

    public DateTime? LastModifiedOn { get; private set; }

    public string? LastModifiedBy { get; private set; }
}

// I thought about adding a SetCreatedBy( and ), SetLastModifiedBy(), etc. methods to the TrackedEntity
// class, but I don't believe that's the right place for them.
// We want date-stamps to be generated at the repository-level so that
// the values are consistent across all containers.
// In addition, CreatedBy and LastModifiedBy can be populated by taking the current user's
// identity from the HttpContext.
// Either the Mediator pipeline or EF mappings will handle this.

