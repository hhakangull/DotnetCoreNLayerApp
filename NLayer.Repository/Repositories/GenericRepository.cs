using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    // protected readonly AppDbContext _context;
    // private readonly DbSet<T> _dbSet;

    protected AppDbContext Context { get; }
    private DbSet<T> DbSet { get; }

    public GenericRepository(AppDbContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
        // _context = context;
        // _dbSet = dbSet;
    }

    public async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await DbSet.AddRangeAsync(entities);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await DbSet.AnyAsync(predicate);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
    {
        return DbSet.AsNoTracking().AsQueryable();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Remove(T entity)
    {
        DbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        DbSet.RemoveRange(entities);
    }


    public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
    {
        return DbSet.Where(predicate);
    }
}