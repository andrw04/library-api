using Library.Business.Models.Book;

namespace Library.Business.Abstractions;

public interface IBookService
{
    Task<ResponseBookDto> GetBookByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ResponseBookDto> GetBookByIsbnAsync(string isbn, CancellationToken cancellationToken = default);
    Task<IEnumerable<ResponseBookDto>> GetAllBooksAsync(CancellationToken cancellationToken = default);
    Task CreateBookAsync(RequestBookDto book, CancellationToken cancellationToken = default);
    Task DeleteBookAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateBookAsync(int id, RequestBookDto book, CancellationToken cancellationToken = default);
}
