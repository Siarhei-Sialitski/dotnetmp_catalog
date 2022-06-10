using DotNetMP.SharedKernel;
using DotNetMP.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotNetMP.Catalog.Infrastructure.Data;

internal class EfRepository<T> : IRepository<T> where T : EntityBase, IAggregateRoot
{
    protected readonly AppDbContext _dbContext;

    public EfRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Add(entity);

        await SaveChangesAsync(cancellationToken);

        return entity;
    }

    public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Remove(entity);

        await SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
    {
        return await _dbContext
            .Set<T>()
            .FindAsync(new object[] { id }, cancellationToken: cancellationToken);
    }

    public virtual async Task<IList<T>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext
            .Set<T>()
            .ToListAsync(cancellationToken);
    }

    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Update(entity);

        await SaveChangesAsync(cancellationToken);
    }
}
