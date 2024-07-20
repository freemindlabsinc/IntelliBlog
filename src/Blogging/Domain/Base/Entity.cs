namespace Blogging.Domain.Base;

public abstract class Entity<TId> : DomainEventProducer
    where TId : struct, IEquatable<TId>
{
    public TId Id { get; private set; } = default!;
}
