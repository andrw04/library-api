using AutoMapper;
using Library.Business.Abstractions;
using Library.Business.Models.Book;
using Library.DataAccess.Abstractions;
using Library.DataAccess.Models;

namespace Library.Business.Services;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public BookService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseBookDto?> GetBookById(int id)
    {
        var book = await _unitOfWork.BookRepository.GetByIdAsync(
            id,
            b => b.Author,
            b => b.Genre);

        return _mapper.Map<ResponseBookDto>(book);
    }

    public async Task<ResponseBookDto?> GetBookByIsbn(string isbn)
    {
        var books = await _unitOfWork.BookRepository.GetAsync(
            b => b.Isbn.Equals(isbn),
            b => b.Author, b => b.Genre);

        return _mapper.Map<ResponseBookDto>(books.FirstOrDefault());
    }

    public async Task<IEnumerable<ResponseBookDto>> GetAllBooks()
    {
        var books = await _unitOfWork.BookRepository.GetAsync(
            null,
            b => b.Author,
            b => b.Genre);

        return books.Select(b => _mapper.Map<ResponseBookDto>(b));
    }

    public async Task CreateBook(RequestBookDto book)
    {
        try
        {
            await _unitOfWork.BookRepository.AddAsync(_mapper.Map<Book>(book));

            await _unitOfWork.SaveAllAsync();
        }
        catch
        {
            throw;
        }
    }

    public async Task DeleteBook(int id)
    {
        var existsBook = await _unitOfWork.BookRepository.GetByIdAsync(id);

        if (existsBook != null)
        {
            await _unitOfWork.BookRepository.DeleteAsync(existsBook);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public async Task UpdateBook(int id, RequestBookDto book)
    {
        var existedBook = await _unitOfWork.BookRepository.GetByIdAsync(id);

        _mapper.Map(book, existedBook);

        await _unitOfWork.BookRepository.UpdateAsync(existedBook!);
    }
}

