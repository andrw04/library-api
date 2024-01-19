using Library.DataAccess.Abstractions;
using Library.DataAccess.Data;
using Library.DataAccess.Models;

namespace Library.DataAccess.Repository;

public class EfUnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly Lazy<IRepository<User>> _userRepository;
    private readonly Lazy<IRepository<Book>> _bookRepository;
    private readonly Lazy<IRepository<Genre>> _genreRepository;
    private readonly Lazy<IRepository<Author>> _authorRepository;
    public EfUnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        _userRepository = new Lazy<IRepository<User>>(() => new EfRepository<User>(context));
        _bookRepository = new Lazy<IRepository<Book>>(() => new EfRepository<Book>(context));
        _genreRepository = new Lazy<IRepository<Genre>>(() => new EfRepository<Genre>(context));
        _authorRepository = new Lazy<IRepository<Author>>(() => new EfRepository<Author>(context));
    }

    public IRepository<Book> BookRepository => _bookRepository.Value;

    public IRepository<User> UserRepository => _userRepository.Value!;

    public IRepository<Genre> GenreRepository => _genreRepository.Value!;

    public IRepository<Author> AuthorRepository => _authorRepository.Value!;

    public async Task CreateDatabaseAsync(CancellationToken cancellationToken = default)
    {
        await _context.Database.EnsureCreatedAsync(cancellationToken);
    }

    public async Task RemoveDatabaseAsync(CancellationToken cancellationToken = default)
    {
        await _context.Database.EnsureDeletedAsync(cancellationToken);
    }

    public async Task SaveAllAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
