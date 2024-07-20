namespace Blogging.Domain.Interfaces;

public interface IEntityRepository<TEntity>
    where TEntity : Entity, IAggregateRoot    
{
    Task<Result<TEntity>> FindAsync<TId>(TId id, CancellationToken cancellationToken)
        where TId : struct, IEquatable<TId>;
    IQueryable<TEntity> Source { get; }


    Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken);
    Task<Result<int>> DeleteAsync<TId>(TId entity, CancellationToken cancellationToken);
    Task<Result<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
