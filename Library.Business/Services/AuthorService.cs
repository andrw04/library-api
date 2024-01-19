using AutoMapper;
using FluentValidation;
using Library.Business.Abstractions;
using Library.Business.Exceptions;
using Library.Business.Models.Author;
using Library.DataAccess.Abstractions;
using Library.DataAccess.Models;

namespace Library.Business.Services;

public class AuthorService : IAuthorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<RequestAuthorDto> _validator;
    public AuthorService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<RequestAuthorDto> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task CreateAuthorAsync(RequestAuthorDto author)
    {
        _validator.ValidateAndThrow(author);

        var authors = await _unitOfWork.AuthorRepository.GetAsync(a 
            => a.FirstName.Equals(author.FirstName) && a.LastName.Equals(author.LastName));

        var existsAuthor = authors.FirstOrDefault();

        if (existsAuthor != null)
            throw new AlreadyExistsException(nameof(Author));

        await _unitOfWork.AuthorRepository.AddAsync(_mapper.Map<Author>(author));

        await _unitOfWork.SaveAllAsync();
    }

    public async Task DeleteAuthorAsync(int id)
    {
        if (id < 1)
            throw new ArgumentException("Id should be greater than 0.");

        var existsAuthor = await _unitOfWork.AuthorRepository.GetByIdAsync(id);

        if (existsAuthor == null)
            throw new IsNotExistsException(nameof(Author));

        await _unitOfWork.AuthorRepository.DeleteAsync(existsAuthor);

        await _unitOfWork.SaveAllAsync();
    }

    public async Task<IEnumerable<ResponseAuthorDto>> GetAllAuthorsAsync()
    {
        var authors = await _unitOfWork.AuthorRepository.GetAsync();

        return authors.Select(a => _mapper.Map<ResponseAuthorDto>(a));
    }

    public async Task<ResponseAuthorDto> GetAuthorByIdAsync(int id)
    {
        if (id < 1)
            throw new ArgumentException("Id should be greater than 0.");

        var author = await _unitOfWork.AuthorRepository.GetByIdAsync(id);

        if (author == null)
            throw new IsNotExistsException(nameof(Author));

        return _mapper.Map<ResponseAuthorDto>(author);
    }

    public async Task UpdateAuthorAsync(int id, RequestAuthorDto author)
    {
        if (id < 1)
            throw new ArgumentException("Id should be greater than 0.");

        var existsAuthor = await _unitOfWork.AuthorRepository.GetByIdAsync(id);

        if (existsAuthor == null)
            throw new IsNotExistsException(nameof(Author));

        _mapper.Map(author, existsAuthor);

        await _unitOfWork.AuthorRepository.UpdateAsync(existsAuthor!);

        await _unitOfWork.SaveAllAsync();
    }
}
