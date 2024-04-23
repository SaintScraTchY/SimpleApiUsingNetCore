namespace NS.Domain.Common;

public interface IBaseEntityRepository<TKey,TEntity> where TEntity : class
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> GetByIdAsync(TKey id);
    Task<IReadOnlyList<TEntity>> GetAllAsync();
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    void SaveChanges();
}