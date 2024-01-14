using Library.Business.Models.Author;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        [HttpGet]
        public Task<ActionResult> GetAuthors()
        {
            throw new NotImplementedException();
        }

        [HttpGet("id:int")]
        public Task<ActionResult> GetAuthorById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<ActionResult> CreateAuthor([FromBody] RequestAuthorDto author)
        {
            throw new NotImplementedException();
        }

        [HttpPut("id:int")]
        public Task<ActionResult> UpdateAuthor(int id, [FromBody] RequestAuthorDto author)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("id:int")]
        public Task<ActionResult> DeleteAuthor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
