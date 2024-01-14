using Library.Business.Models.Author;
using Library.Business.Models.Utility;

namespace Library.Business.Abstractions
{
    public interface IAuthorService
    {
        Task<ResponseData<ResponseAuthorDto?>> GetAuthorById(int id);
        Task<ResponseData<IEnumerable<ResponseAuthorDto>>> GetAllAuthors();
        Task<ResponseData<ResponseAuthorDto?>> CreateAuthor(RequestAuthorDto author);
        Task<ResponseData<ResponseAuthorDto?>> DeleteAuthor(int id);
        Task<ResponseData<ResponseAuthorDto?>> UpdateAuthor(int id, RequestAuthorDto author);
    }
}
