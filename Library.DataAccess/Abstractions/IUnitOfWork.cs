using Library.DataAccess.Models;

namespace Library.DataAccess.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Book> BookRepository { get; }
        IRepository<User> UserRepository { get; }
        Task RemoveDatabaseAsync();
        Task CreateDatabaseAsync();
        Task SaveAllAsync();
    }
}
