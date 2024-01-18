using Library.Business.Models.Author;

namespace Library.Business.Abstractions;

public interface IAuthorService
{
    Task<ResponseAuthorDto> GetAuthorByIdAsync(int id);
    Task<IEnumerable<ResponseAuthorDto>> GetAllAuthorsAsync();
    Task CreateAuthorAsync(RequestAuthorDto author);
    Task DeleteAuthorAsync(int id);
    Task UpdateAuthorAsync(int id, RequestAuthorDto author);
}
