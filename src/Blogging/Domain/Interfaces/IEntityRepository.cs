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
    /// Gets an aggregate root by its id.
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TAggregateRoot?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default)
        where TId : struct;

    /// <summary>
    /// Persists a new aggregate root.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TAggregateRoot> AddAsync(TAggregateRoot entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing aggregate root.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TAggregateRoot> UpdateAsync(TAggregateRoot entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an existing aggregate root.
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    /// <param name="entityId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync<TId>(TId entityId, CancellationToken cancellationToken = default)
        where TId : struct;    
}
