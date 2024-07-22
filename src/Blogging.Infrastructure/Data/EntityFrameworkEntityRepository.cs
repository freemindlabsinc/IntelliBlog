using Blogging.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Blogging.Infrastructure.Data;

public sealed class EntityFrameworkEntityRepository<T>(
    BloggingDbContext _dbContext) : IEntityRepository<T>

    where T : Entity, IAggregateRoot
{
    public IQueryable<T> Source => _dbContext.Set<T>();

    DbSet<T> DbSet => _dbContext.Set<T>();

    public async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken) 
        where TId : struct
    {
        var entity = await DbSet.FindAsync(id, cancellationToken);

        return entity;
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        DbSet.Add(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<bool> DeleteAsync<TId>(TId id, CancellationToken cancellationToken)
        where TId : struct
    {
        var entity = await GetByIdAsync<TId>(id, cancellationToken);

        if (entity == null) 
            return false;

        DbSet.Remove(entity);
        
        //
        var changes = await _dbContext.SaveChangesAsync(cancellationToken);

        return (changes > 0);
    }

    public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        EntityEntry<T> entry = DbSet.Update(entity);
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return entry.Entity;
    }
}
