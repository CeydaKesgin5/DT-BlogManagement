using Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories
{
    public abstract class Repository<T> : IRepository<T>
    where T : class, new()
    {
        protected readonly AppDbContext _context;

        protected Repository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges
                ? _context.Set<T>()
                : _context.Set<T>().AsNoTracking();
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
                ? _context.Set<T>().Where(expression).SingleOrDefault()
                : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
    //public class Repository<T> : IRepository<T> where T : class

    //{
    //    private readonly AppDbContext _context;
    //    private readonly DbSet<T> _dbSet;

    //    public Repository(AppDbContext context)
    //    {
    //        _context = context;
    //        _dbSet = context.Set<T>();
    //    }

    //    public async Task<IEnumerable<T>> GetAllAsync()
    //    {
    //        return await _dbSet.ToListAsync();
    //    }

    //    public async Task<T> GetByIdAsync(int id)
    //    {
    //        return await _dbSet.FindAsync(id);
    //    }

    //    public async Task AddAsync(T entity)
    //    {
    //        await _dbSet.AddAsync(entity);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task UpdateAsync(T entity)
    //    {
    //        _dbSet.Update(entity);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task DeleteAsync(int id)
    //    {
    //        var entity = await GetByIdAsync(id);
    //        if (entity != null)
    //        {
    //            _dbSet.Remove(entity);
    //            await _context.SaveChangesAsync();
    //        }
    //    }
    //}
}
