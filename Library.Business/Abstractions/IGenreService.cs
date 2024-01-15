using Library.Business.Models.Genre;
using Library.Business.Models.Utility;

namespace Library.Business.Abstractions
{
    public interface IGenreService
    {
        Task<ResponseData<ResponseGenreDto?>> GetGenreById(int id);
        Task<ResponseData<IEnumerable<ResponseGenreDto>>> GetAllGenres();
        Task<ResponseData<ResponseGenreDto?>> CreateGenre(RequestGenreDto genre);
        Task<ResponseData<ResponseGenreDto?>> DeleteGenre(int id);
        Task<ResponseData<ResponseGenreDto?>> UpdateGenre(int id, RequestGenreDto genre);
    }
}
