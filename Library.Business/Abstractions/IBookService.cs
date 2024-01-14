using Library.Business.Models.Book;
using Library.Business.Models.Utility;

namespace Library.Business.Abstractions
{
    public interface IBookService
    {
        Task<ResponseData<ResponseBookDto?>> GetBookById(int id);
        Task<ResponseData<ResponseBookDto?>> GetBookByIsbn(string isbn);
        Task<ResponseData<IEnumerable<ResponseBookDto>>> GetAllBooks();
        Task<ResponseData<ResponseBookDto?>> CreateBook(RequestBookDto book);
        Task<ResponseData<ResponseBookDto?>> DeleteBook(int id);
        Task<ResponseData<ResponseBookDto?>> UpdateBook(int id, RequestBookDto book);
    }
}
