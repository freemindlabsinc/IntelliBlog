namespace Blogging.Domain;

public abstract class Entity<TId> : DomainEventNotifier
    where TId : struct, IEquatable<TId>
{
    public TId Id { get; protected set; } = default!;
}
