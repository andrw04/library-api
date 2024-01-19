using AutoMapper;
using FluentValidation;
using Library.Business.Abstractions;
using Library.Business.Exceptions;
using Library.Business.Models.Genre;
using Library.DataAccess.Abstractions;
using Library.DataAccess.Models;

namespace Library.Business.Services;

public class GenreService : IGenreService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<RequestGenreDto> _validator;
    public GenreService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<RequestGenreDto> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task CreateGenreAsync(RequestGenreDto genre, CancellationToken cancellationToken = default)
    {
        _validator.ValidateAndThrow(genre);

        var genres = await _unitOfWork.GenreRepository.GetAsync(cancellationToken, g => g.Equals(genre.Name));

        var existsGenre = genres.FirstOrDefault();

        if (existsGenre != null)
            throw new AlreadyExistsException(nameof(Genre));

        await _unitOfWork.GenreRepository.AddAsync(_mapper.Map<Genre>(genre), cancellationToken);

        await _unitOfWork.SaveAllAsync(cancellationToken);
    }

    public async Task DeleteGenreAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id < 1)
            throw new ArgumentException("Id should be greater than 0.");

        var existsGenre = await _unitOfWork.GenreRepository.GetByIdAsync(id, cancellationToken);

        if (existsGenre == null)
            throw new IsNotExistsException(nameof(Genre));

        await _unitOfWork.GenreRepository.DeleteAsync(existsGenre, cancellationToken);

        await _unitOfWork.SaveAllAsync(cancellationToken);
    }

    public async Task<IEnumerable<ResponseGenreDto>> GetAllGenresAsync(CancellationToken cancellationToken = default)
    {
        var genres = await _unitOfWork.GenreRepository.GetAsync(cancellationToken);

        return genres.Select(g => _mapper.Map<ResponseGenreDto>(g));
    }

    public async Task<ResponseGenreDto> GetGenreByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id < 1)
            throw new ArgumentException("id should be greater than 0.");

        var genre = await _unitOfWork.GenreRepository.GetByIdAsync(id, cancellationToken);

        if (genre == null)
            throw new IsNotExistsException(nameof(Genre));

        return _mapper.Map<ResponseGenreDto>(genre);
    }

    public async Task UpdateGenreAsync(int id, RequestGenreDto genre, CancellationToken cancellationToken = default)
    {
        if (id < 1)
            throw new ArgumentException("Id should be greater than 0.");

        _validator.ValidateAndThrow(genre);

        var genres = await _unitOfWork.GenreRepository.GetAsync(cancellationToken, g => g.Equals(genre.Name));

        var existsGenre = genres.FirstOrDefault();

        if (existsGenre != null)
            throw new AlreadyExistsException(nameof(Genre));

        existsGenre = await _unitOfWork.GenreRepository.GetByIdAsync(id, cancellationToken);

        if (existsGenre == null)
            throw new IsNotExistsException(nameof(Genre));

        _mapper.Map(genre, existsGenre);

        await _unitOfWork.GenreRepository.UpdateAsync(existsGenre!, cancellationToken);

        await _unitOfWork.SaveAllAsync(cancellationToken);
    }
}
