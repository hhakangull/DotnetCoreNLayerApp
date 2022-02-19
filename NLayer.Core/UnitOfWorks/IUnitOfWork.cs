namespace NLayer.Core.UnitOfWorks;

public interface IUnitOfWork
{
    Task CommitAsync();
    Task Commit();
}