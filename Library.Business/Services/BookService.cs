using AutoMapper;
using FluentValidation;
using Library.Business.Abstractions;
using Library.Business.Models.Book;
using Library.Business.Models.Utility;
using Library.DataAccess.Abstractions;
using Library.DataAccess.Models;

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
    public async Task<ResponseData<ResponseBookDto?>> GetBookById(int id)
    {
        try
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
    }
}
