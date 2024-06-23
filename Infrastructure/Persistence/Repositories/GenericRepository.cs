using Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class GenericRepository<TEntity>(BlogDbContext context): IGenericRepository<TEntity> where TEntity: class
{
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    
    public async Task<List<TEntity>> GetAllAsync()
    {
        var entry = await _dbSet.ToListAsync();
        return entry;
    }
    
    public async Task<TEntity?> GetByIdAsync(int id)
    {
        var entry = await _dbSet.FindAsync(id);
        return entry;
    }
    
    public  async Task<TEntity> AddAsync(TEntity entity)
    {
        var entityEntry = await _dbSet.AddAsync(entity);
        return entityEntry.Entity;
    }
    
    public TEntity Update(TEntity entity)
    {
        var entry = _dbSet.Update(entity);
        return entry.Entity;
    }
    
    public async Task<TEntity?> DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
        {
            return null;
        }

        _dbSet.Remove(entity);
        await context.SaveChangesAsync();

        return entity;
    }
}