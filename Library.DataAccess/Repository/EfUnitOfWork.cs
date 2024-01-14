using Library.DataAccess.Abstractions;
using Library.DataAccess.Data;
using Library.DataAccess.Models;

namespace Library.DataAccess.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<IRepository<User>> _userRepository;
        private readonly Lazy<IRepository<Book>> _bookRepository;
        public EfUnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            _userRepository = new Lazy<IRepository<User>>(() => new EfRepository<User>(context));
            _bookRepository = new Lazy<IRepository<Book>>(() => new EfRepository<Book>(context));
        }

        public IRepository<Book> Books => _bookRepository.Value;

        public IRepository<User> Users => _userRepository.Value!;

        public async Task CreateDatabaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }

        public async Task RemoveDatabaseAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
