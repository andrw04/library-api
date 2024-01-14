using Library.DataAccess.Models;

namespace Library.Business.Abstractions;
public interface IBookService
{
    Task<Book?> GetBookById(int id);
    Task<Book?> GetBookByIsbn(string isbn);
    Task<IEnumerable<Book>> GetAllBooks();
    Task CreateBook(Book book);
    Task DeleteBook(int id);
    Task UpdateBook(int id, Book book);
}
