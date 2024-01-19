using Library.DataAccess.Models;

namespace Library.DataAccess.Abstractions;

public interface IUnitOfWork
{
    IRepository<Book> BookRepository { get; }
    IRepository<Genre> GenreRepository { get; }
    IRepository<Author> AuthorRepository { get; }
    IRepository<User> UserRepository { get; }
    Task RemoveDatabaseAsync(CancellationToken cancellationToken = default);
    Task CreateDatabaseAsync(CancellationToken cancellationToken = default);
    Task SaveAllAsync(CancellationToken cancellationToken = default);
}
