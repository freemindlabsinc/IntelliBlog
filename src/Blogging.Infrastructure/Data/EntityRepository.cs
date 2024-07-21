using Ardalis.Result;
using Blogging.Domain.Interfaces;

namespace Blogging.Infrastructure.Data;

public sealed class EntityRepository<T>(BloggingDbContext _dbContext) : IEntityRepository<T>
    where T : Entity, IAggregateRoot
{
    public IQueryable<T> Source => _dbContext.Set<T>();

    public async Task<Result<T>> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken) where TId : struct, IEquatable<TId>
    {
        var entity = await _dbContext.Set<T>().FindAsync(id, cancellationToken);

        if (entity == null)
            return Result.NotFound();

        return Result<T>.Success(entity);
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<T>()
                  .Add(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<Result<int>> DeleteAsync<TId>(TId id, CancellationToken cancellationToken)
        where TId : struct
    {
        var entity = await _dbContext.Set<T>().FindAsync(id, cancellationToken);

        if (entity == null) 
            return Result.NotFound();

        _dbContext.Set<T>()
                  .Remove(entity);

        var changes = await _dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(changes);
    }

    public async Task<Result<T>> UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<T>().Update(entity);

        if (entity == null)
            return Result.NotFound();

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result<T>.Success(entity);
    }
}
