using Library.Business.Models.Author;

namespace Library.Business.Abstractions;

public interface IAuthorService
{
    Task<ResponseAuthorDto> GetAuthorById(int id);
    Task<IEnumerable<ResponseAuthorDto>> GetAllAuthors();
    Task CreateAuthor(RequestAuthorDto author);
    Task DeleteAuthor(int id);
    Task UpdateAuthor(int id, RequestAuthorDto author);
}
