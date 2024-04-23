using Microsoft.EntityFrameworkCore;
using NS.Domain.Common;

namespace NS.Infrastructure.MSSQL.EFCore.Repositories;

public class BaseEntityRepository<TKey,TEntity> : IBaseEntityRepository<TKey,TEntity> where TEntity : class
{
    private readonly DbContext _context;

    public BaseEntityRepository(DbContext context)
    {
        _context = context;
    }
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        return (await _context.AddAsync(entity)).Entity;
    }

    public async Task<TEntity> GetByIdAsync(TKey id)
    {
        return await _context.FindAsync<TEntity>(id);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public Task UpdateAsync(TEntity entity)
    {
        _context.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(TEntity entity)
    {
        _context.Remove(entity);
        return Task.CompletedTask;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}