namespace Domain.Interface;

public interface IGenericRepository<TEntity> where TEntity: class
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task<TEntity> AddAsync(TEntity entity);
    TEntity Update(TEntity entity);
    Task<TEntity?> DeleteAsync(int id);
}
