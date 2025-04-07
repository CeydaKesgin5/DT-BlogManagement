using System.Linq.Expressions;

namespace BlogManagement.Repositories.Contracts
{
    public interface IRepository<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Remove(T entity);



    }
}
