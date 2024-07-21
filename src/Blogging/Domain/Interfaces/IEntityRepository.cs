namespace Blogging.Domain.Interfaces;

public interface IEntityRepository<TAggregateRoot>
    where TAggregateRoot : Entity, IAggregateRoot    
{
    Task<Result<TAggregateRoot>> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default)
        where TId : struct, IEquatable<TId>;
    IQueryable<TAggregateRoot> Source { get; }

    Task<TAggregateRoot> CreateAsync(TAggregateRoot entity, CancellationToken cancellationToken = default);
    Task<Result<TAggregateRoot>> UpdateAsync(TAggregateRoot entity, CancellationToken cancellationToken = default);
    Task<Result<int>> DeleteAsync<TId>(TId entity, CancellationToken cancellationToken = default)
        where TId : struct;    

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
