using Library.Business.Abstractions;
using Library.Business.Models.Author;

namespace Library.Business.Services
{
    public class AuthorService : IAuthorService
    {
        public Task CreateAuthor(RequestAuthorDto author)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ResponseAuthorDto>> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseAuthorDto?> GetAuthorById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAuthor(int id, RequestAuthorDto author)
        {
            throw new NotImplementedException();
        }
    }
}
