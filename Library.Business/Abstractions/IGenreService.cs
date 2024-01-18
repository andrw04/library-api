using Library.Business.Models.Genre;

namespace Library.Business.Abstractions;

public interface IGenreService
{
    Task<ResponseGenreDto> GetGenreByIdAsync(int id);
    Task<IEnumerable<ResponseGenreDto>> GetAllGenresAsync();
    Task CreateGenreAsync(RequestGenreDto genre);
    Task DeleteGenreAsync(int id);
    Task UpdateGenreAsync(int id, RequestGenreDto genre);
}
