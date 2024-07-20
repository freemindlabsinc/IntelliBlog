namespace Blogging.Domain.Base;

public abstract class Entity : DomainEventProducer
{ }

public abstract class Entity<TId> : Entity
    where TId : struct, IEquatable<TId>
{
    public TId Id { get; private set; } = default!;
}
