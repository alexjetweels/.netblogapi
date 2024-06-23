using Domain.Interface;

namespace Infrastructure.Persistence.Repositories;

public class UnitOfWork(BlogDbContext context): IUnitOfWork
{
    public void Commit()
    {
        context.SaveChanges();
    }
    
    public async Task CommitAsync()
    {
       await context.SaveChangesAsync();
    }
}