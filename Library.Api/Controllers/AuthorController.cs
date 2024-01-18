using Library.Business.Abstractions;
using Library.Business.Models.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        /// Returns all authors
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAuthors()
        {
            return Ok();
        }

        /// <summary>
        /// Returns author by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("id:int")]
        public async Task<ActionResult> GetAuthorById(int id)
        {
            return Ok();
        }

        /// <summary>
        /// Creates author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateAuthor([FromBody] RequestAuthorDto author)
        {
            return Ok();
        }

        /// <summary>
        /// Updates author by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="author"></param>
        /// <returns></returns>

        [HttpPut("id:int")]
        public async Task<ActionResult> UpdateAuthor(int id, [FromBody] RequestAuthorDto author)
        {
            return Ok();
        }

        /// <summary>
        /// Deletes author by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id:int")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            return Ok();
        }
    }
}
