using NLayer.Core.UnitOfWorks;

namespace NLayer.Repository.UnitOfWorks;

public class UnitOfWork: IUnitOfWork
{
    private AppDbContext Context { get;  }

    public UnitOfWork(AppDbContext context)
    {
        Context = context;
    }

    public async Task CommitAsync()
    {
        await Context.SaveChangesAsync();
    }

    public void Commit()
    {
        Context.SaveChanges();
    }
}