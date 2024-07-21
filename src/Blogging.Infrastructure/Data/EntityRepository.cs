using System.Linq;
using System.Xml.Linq;
using Ardalis.Result;
using Blogging.Domain.Interfaces;

namespace Infrastructure2.Data;

public class EntityRepository<T> : IEntityRepository<T>
    where T : Entity, IAggregateRoot
{
    private readonly AppDbContext _dbContext;
    
    public EntityRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;        
    }

    public IQueryable<T> Source => _dbContext.Set<T>();

    public async Task<Result<T>> FindAsync<TId>(TId id, CancellationToken cancellationToken) where TId : struct, IEquatable<TId>
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);

        if (entity == null)
            return Result.NotFound();

        return Result<T>.Success(entity);
    }

    public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<T>()
                  .Add(entity);

        await SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<Result<int>> DeleteAsync<TId>(TId id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);

        if (entity == null) 
            return Result.NotFound();

        _dbContext.Set<T>()
                  .Remove(entity);

        var changes = await SaveChangesAsync(cancellationToken);

        return Result.Success(changes);
    }

    public async Task<Result<T>> UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<T>().Update(entity);

        if (entity == null)
            return Result.NotFound();

        await SaveChangesAsync(cancellationToken);

        return Result<T>.Success(entity);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
