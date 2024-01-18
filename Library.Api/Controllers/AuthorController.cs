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
        public async Task<ActionResult> GetAuthorsAsync()
        {
            var authors = await _authorService.GetAllAuthors();

            return Ok(authors);
        }

        /// <summary>
        /// Returns author by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("id:int")]
        public async Task<ActionResult> GetAuthorByIdAsync(int id)
        {
            var author = await _authorService.GetAuthorById(id);

            return Ok(author);
        }

        /// <summary>
        /// Creates author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateAuthorAsync([FromBody] RequestAuthorDto author)
        {
            await _authorService.CreateAuthor(author);

            return StatusCode(201);
        }

        /// <summary>
        /// Updates author by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="author"></param>
        /// <returns></returns>

        [HttpPut("id:int")]
        public async Task<ActionResult> UpdateAuthorAsync(int id, [FromBody] RequestAuthorDto author)
        {
            await _authorService.UpdateAuthor(id, author);

            return Ok();
        }

        /// <summary>
        /// Deletes author by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id:int")]
        public async Task<ActionResult> DeleteAuthorAsync(int id)
        {
            await _authorService.DeleteAuthor(id);

            return StatusCode(204);
        }
    }
}
