using Library.Business.Models.Book;

namespace Library.Business.Abstractions;

public interface IBookService
{
    Task<ResponseBookDto> GetBookByIdAsync(int id);
    Task<ResponseBookDto> GetBookByIsbnAsync(string isbn);
    Task<IEnumerable<ResponseBookDto>> GetAllBooksAsync();
    Task CreateBookAsync(RequestBookDto book);
    Task DeleteBookAsync(int id);
    Task UpdateBookAsync(int id, RequestBookDto book);
}
