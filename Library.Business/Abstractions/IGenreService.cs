using Library.Business.Models.Genre;

namespace Library.Business.Abstractions
{
    public interface IGenreService
    {
        Task<ResponseGenreDto?> GetGenreById(int id);
        Task<IEnumerable<ResponseGenreDto>> GetAllGenres();
        Task CreateGenre(RequestGenreDto genre);
        Task DeleteGenre(int id);
        Task UpdateGenre(int id, RequestGenreDto genre);
    }
}
