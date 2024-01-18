using System.Linq.Expressions;

namespace Library.DataAccess.Abstractions
{
    public interface IRepository<T>
    {
        Task Add(T item);
        Task Update(T item);
        Task Delete(T item);
        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>>? filter = null,
            params Expression<Func<T, object>>[] includeProperties);
        Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includesProperties);
    }
}
