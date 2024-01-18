using Library.DataAccess.Abstractions;
using Library.DataAccess.Data;
using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.DataAccess.Repository
{
    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext _context;
        public EfRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task Add(T item)
        {
            _context.Add(item);

            return Task.CompletedTask;
        }

        public Task Delete(T item)
        {
            _context.Remove(item);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>>? filter = null,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _context.Set<T>().AsQueryable();

            if (includeProperties.Any())
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _context.Set<T>().AsQueryable();

            if (includeProperties.Any())
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;

            return Task.CompletedTask;
        }
    }
}
