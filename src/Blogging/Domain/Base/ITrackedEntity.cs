namespace Blogging.Domain.Base;

public interface ITrackedEntity
{
    public DateTimeOffset CreatedOn { get; }

    public string? CreatedBy { get; }

    public DateTimeOffset? LastModifiedOn { get; }

    public string? LastModifiedBy { get; }

    void SetCreated(DateTimeOffset createdOn, string createdBy);

    void SetLastModified(DateTimeOffset lastModifiedOn, string lastModifiedBy);
}

// I thought about adding a SetCreatedBy( and ), SetLastModifiedBy(), etc. methods to the TrackedEntity
// class, but I don't believe that's the right place for them.
// We want date-stamps to be generated at the repository-level so that
// the values are consistent across all containers.
// In addition, CreatedBy and LastModifiedBy can be populated by taking the current user's
// identity from the HttpContext.
// Either the Mediator pipeline or EF mappings will handle this.

