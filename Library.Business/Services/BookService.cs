using Library.Business.Abstractions;
using Library.DataAccess.Models;

namespace Library.Business.Services;

public class BookService : IBookService
{
    public Task<Book?> GetBookById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Book?> GetBookByIsbn(string isbn)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> GetAllBooks()
    {
        throw new NotImplementedException();
    }

    public Task CreateBook(Book book)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBook(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBook(int id, Book book)
    {
        throw new NotImplementedException();
    }
}

