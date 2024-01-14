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
        public async Task AddAsync(T item)
        {
            _context.Add(item);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T item)
        {
            _context.Remove(item);

            await _context.SaveChangesAsync();
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

        public async Task UpdateAsync(T item)
        {
            _context.Entry(item).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
