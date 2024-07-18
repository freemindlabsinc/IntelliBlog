using HotChocolate;
using HotChocolate.Types;

namespace Blogging.Domain;

public abstract class Entity<TId> : HasDomainEvents
    where TId : struct, IEquatable<TId>
{
    [GraphQLType(typeof(IdType))]
    public TId Id { get; protected set; } = default!;
}
