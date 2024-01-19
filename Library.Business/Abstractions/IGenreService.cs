using Library.Business.Models.Genre;

namespace Library.Business.Abstractions;

public interface IGenreService
{
    Task<ResponseGenreDto> GetGenreByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ResponseGenreDto>> GetAllGenresAsync(CancellationToken cancellationToken = default);
    Task CreateGenreAsync(RequestGenreDto genre, CancellationToken cancellationToken = default);
    Task DeleteGenreAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateGenreAsync(int id, RequestGenreDto genre, CancellationToken cancellationToken = default);
}
