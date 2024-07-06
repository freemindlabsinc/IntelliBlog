namespace IntelliBlog.Domain;

public abstract class Entity<TId> : HasDomainEvents
    where TId : struct, IEquatable<TId>
{
    public TId Id { get; protected set; } = default!;
}
