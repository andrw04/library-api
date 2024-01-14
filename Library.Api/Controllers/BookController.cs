using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpGet("id:int")]
        public async Task<ActionResult> GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpGet("isbn")]
        public async Task<ActionResult> GetBookByIsbn(string isbn)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBook()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBook()
        {
            throw new NotImplementedException();
        }
    }
}
