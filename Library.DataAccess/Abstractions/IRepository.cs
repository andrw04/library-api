using System.Linq.Expressions;

namespace Library.DataAccess.Abstractions;

public interface IRepository<T>
{
    Task AddAsync(T item, CancellationToken cancellationToken = default);
    Task UpdateAsync(T item, CancellationToken cancellationToken = default);
    Task DeleteAsync(T item, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAsync(
        CancellationToken cancellationToken = default,
        Expression<Func<T, bool>>? filter = null,
        params Expression<Func<T, object>>[] includeProperties);
    Task<T?> GetByIdAsync(
        int id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includesProperties);
}
