using Library.DataAccess.Models;

namespace Library.DataAccess.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Book> Books { get; }
        IRepository<User> Users { get; }
        Task RemoveDatabaseAsync();
        Task CreateDatabaseAsync();
        Task SaveAllAsync();
    }
}
