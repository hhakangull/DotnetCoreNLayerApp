using System.Linq.Expressions;

namespace NLayer.Core.Services;

public interface IService<T> where T : class
{
    Task<T> GetByIdAsync(int id);

    Task<IEnumerable<T>> GetAllAsync();

    IEnumerable<T> Where(Expression<Func<T, bool>> predicate);

    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

    Task AddAsync(T entity);

    Task AddRangeAsync(IEnumerable<T> entities);

    Task UpdateAsync(T entity);

    Task RemoveAsync(T entity);

    Task RemoveRangeAsync(IEnumerable<T> entities);
}