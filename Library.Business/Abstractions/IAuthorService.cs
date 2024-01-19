using Library.Business.Models.Author;

namespace Library.Business.Abstractions;

public interface IAuthorService
{
    Task<ResponseAuthorDto> GetAuthorByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ResponseAuthorDto>> GetAllAuthorsAsync(CancellationToken cancellationToken = default);
    Task CreateAuthorAsync(RequestAuthorDto author, CancellationToken cancellationToken = default);
    Task DeleteAuthorAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateAuthorAsync(int id, RequestAuthorDto author, CancellationToken cancellationToken = default);
}
