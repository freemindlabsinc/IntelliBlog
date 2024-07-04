using Ardalis.SharedKernel;

namespace IntelliBlog.Domain;

public abstract class Entity<TId> : HasDomainEventsBase
    where TId : struct, IEquatable<TId>
{
    public TId Id { get; protected set; } = default!;
}
