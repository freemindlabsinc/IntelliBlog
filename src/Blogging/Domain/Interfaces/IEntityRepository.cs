namespace Blogging.Domain.Interfaces;

public interface IEntityRepository<TEntity>
    where TEntity : Entity, IAggregateRoot    
{
    Task<Result<TEntity>> FindAsync<TId>(TId id, CancellationToken cancellationToken = default)
        where TId : struct, IEquatable<TId>;
    IQueryable<TEntity> Source { get; }

    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<Result<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<Result<int>> DeleteAsync<TId>(TId entity, CancellationToken cancellationToken = default);    

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
