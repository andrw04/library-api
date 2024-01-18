using AutoMapper;
using FluentValidation;
using Library.Business.Abstractions;
using Library.Business.Exceptions;
using Library.Business.Models.Book;
using Library.DataAccess.Abstractions;
using Library.DataAccess.Models;
using Library.DataAccess.Repository;

namespace Library.Business.Services;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<RequestBookDto> _validator;
    public BookService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<RequestBookDto> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task CreateBookAsync(RequestBookDto book)
    {
        _validator.ValidateAndThrow(book);

        var existsBook = await GetBookByIsbnAsync(book.Isbn);

        if (existsBook != null)
            throw new AlreadyExistsException("Book");

        await _unitOfWork.BookRepository.AddAsync(_mapper.Map<Book>(book));

        await _unitOfWork.SaveAllAsync();
    }

    public async Task DeleteBookAsync(int id)
    {
        if (id < 1)
            throw new ArgumentException("Id should be greater than 0.");

        var existsBook = await _unitOfWork.BookRepository.GetByIdAsync(id);

        if (existsBook == null)
            throw new IsNotExistsException("Book");

        await _unitOfWork.BookRepository.DeleteAsync(existsBook);

        await _unitOfWork.SaveAllAsync();
    }

    public async Task<IEnumerable<ResponseBookDto>> GetAllBooksAsync()
    {
        var books = await _unitOfWork.BookRepository.GetAsync(
           null,
           b => b.Author,
           b => b.Genre);

        return books.Select(b => _mapper.Map<ResponseBookDto>(b));
    }

    public async Task<ResponseBookDto> GetBookByIdAsync(int id)
    {
        if (id < 1)
            throw new ArgumentException("Id should be greater than 0.");

        var book = await _unitOfWork.BookRepository.GetByIdAsync(
        id,
        b => b.Author,
        b => b.Genre);

        if (book == null)
            throw new IsNotExistsException("Book");

        return _mapper.Map<ResponseBookDto>(book);
    }

    public async Task<ResponseBookDto> GetBookByIsbnAsync(string isbn)
    {
        var books = await _unitOfWork.BookRepository.GetAsync(
           b => b.Isbn.Equals(isbn),
           b => b.Author, b => b.Genre);

        var existsBook = books.FirstOrDefault();

        if (existsBook == null)
            throw new IsNotExistsException("Book");

        return _mapper.Map<ResponseBookDto>(existsBook);
    }

    public async Task UpdateBookAsync(int id, RequestBookDto book)
    {
        if (id < 1)
            throw new ArgumentException("Id should be greater than 0.");

        var existsBook = await _unitOfWork.BookRepository.GetByIdAsync(id);

        if (existsBook == null)
            throw new IsNotExistsException("Book");

        _mapper.Map(book, existsBook);

        await _unitOfWork.BookRepository.UpdateAsync(existsBook!);

        await _unitOfWork.SaveAllAsync();
    }


    /*public async Task<ResponseData<ResponseBookDto?>> GetBookById(int id)
{
       var book = await _unitOfWork.BookRepository.GetByIdAsync(
           id,
           b => b.Author,
           b => b.Genre);

       return new ResponseData<ResponseBookDto?>
       {
           Data = _mapper.Map<ResponseBookDto>(book)
       };
   }
}

public async Task<ResponseData<ResponseBookDto?>> GetBookByIsbn(string isbn)
{
   try
   {
       var books = await _unitOfWork.BookRepository.GetAsync(
           b => b.Isbn.Equals(isbn),
           b => b.Author, b => b.Genre);

       return new ResponseData<ResponseBookDto?>
       {
           Data = _mapper.Map<ResponseBookDto>(books.First())
       };
   }
   catch (Exception ex)
   {
       return new ResponseData<ResponseBookDto?>
       {
           Data = null,
           IsSuccess = false,
           ExceptionData = ex
       };
   }
}

public async Task<ResponseData<IEnumerable<ResponseBookDto>>> GetAllBooks()
{
   try
   {
       var books = await _unitOfWork.BookRepository.GetAsync(
           null,
           b => b.Author,
           b => b.Genre);

       return new ResponseData<IEnumerable<ResponseBookDto>>
       {
           Data = books.Select(b => _mapper.Map<ResponseBookDto>(b))
       };
   }
   catch (Exception ex)
   {
       return new ResponseData<IEnumerable<ResponseBookDto>>
       {
           Data = null,
           IsSuccess = false,
           ExceptionData = ex
       };
   }
}

public async Task<ResponseData<ResponseBookDto?>> CreateBook(RequestBookDto book)
{
   try
   {
       _validator.ValidateAndThrow(book);

       await _unitOfWork.BookRepository.AddAsync(_mapper.Map<Book>(book));

       await _unitOfWork.SaveAllAsync();

       return new ResponseData<ResponseBookDto?>();
   }
   catch (Exception ex)
   {
       return new ResponseData<ResponseBookDto?>
       {
           Data = null,
           IsSuccess = false,
           ExceptionData = ex
       };
   }
}

public async Task<ResponseData<ResponseBookDto?>> DeleteBook(int id)
{
   try
   {
       var existsBook = await _unitOfWork.BookRepository.GetByIdAsync(id);

       if (existsBook == null)
       {
           throw new InvalidOperationException();
       }

       await _unitOfWork.BookRepository.DeleteAsync(existsBook);

       return new ResponseData<ResponseBookDto?>();
   }
   catch (Exception ex)
   {
       return new ResponseData<ResponseBookDto?>
       {
           Data = null,
           IsSuccess = false,
           ExceptionData = ex
       };
   }
}

public async Task<ResponseData<ResponseBookDto?>> UpdateBook(int id, RequestBookDto book)
{
   try
   {
       _validator.ValidateAndThrow(book);

       var existsBook = await _unitOfWork.BookRepository.GetByIdAsync(id);

       _mapper.Map(book, existsBook);

       await _unitOfWork.BookRepository.UpdateAsync(existsBook!);

       return new ResponseData<ResponseBookDto?>();
   }
   catch (Exception ex)
   {
       return new ResponseData<ResponseBookDto?>
       {
           Data = null,
           IsSuccess = false,
           ExceptionData = ex
       };
   }
}*/
}
