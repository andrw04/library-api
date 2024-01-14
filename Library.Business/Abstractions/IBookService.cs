using Library.Business.Models.Book;
using Library.DataAccess.Models;

namespace Library.Business.Abstractions;
public interface IBookService
{
    Task<ResponseBookDto?> GetBookById(int id);
    Task<ResponseBookDto?> GetBookByIsbn(string isbn);
    Task<IEnumerable<ResponseBookDto>> GetAllBooks();
    Task CreateBook(RequestBookDto book);
    Task DeleteBook(int id);
    Task UpdateBook(int id, RequestBookDto book);
}
