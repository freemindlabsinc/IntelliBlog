namespace Blogging.Domain.Interfaces;

/// <summary>
/// A repository that can be used to perform CRUD operations on an entity.
/// </summary>
/// <typeparam name="TAggregateRoot"></typeparam>
public interface IEntityRepository<TAggregateRoot>
    where TAggregateRoot : Entity, IAggregateRoot    
{
    /// <summary>
    /// The IQueryable source for the aggregate.
    /// </summary>
    IQueryable<TAggregateRoot> Source { get; }

    /// <summary>
    /// Gets an aggregate by its id.
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Result<TAggregateRoot>> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default)
        where TId : struct, IEquatable<TId>;

    /// <summary>
    /// Persists a new aggregate.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TAggregateRoot> CreateAsync(TAggregateRoot entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing aggregate.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Result<TAggregateRoot>> UpdateAsync(TAggregateRoot entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an existing aggregate.
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Result<int>> DeleteAsync<TId>(TId entity, CancellationToken cancellationToken = default)
        where TId : struct;

    /// <summary>
    /// Persists all changes made to the aggregate.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
