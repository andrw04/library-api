using Library.Business.Abstractions;
using Library.Business.Models.Genre;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        /// <summary>
        /// Returns all genres
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetGenresAsync()
        {
            var genres = await _genreService.GetAllGenresAsync();

            return Ok();
        }

        /// <summary>
        /// Returns genre by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("id:int")]
        public async Task<IActionResult> GetGenreByIdAsync(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);

            return Ok(genre);
        }

        /// <summary>
        /// Creates new genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateGenreAsync([FromBody] RequestGenreDto genre)
        {
            await _genreService.CreateGenreAsync(genre);

            return StatusCode(201);
        }

        /// <summary>
        /// Updates genre by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="genre"></param>
        /// <returns></returns>
        [HttpPut("id:int")]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] RequestGenreDto genre)
        {
            await _genreService.UpdateGenreAsync(id, genre);

            return Ok();
        }

        /// <summary>
        /// Deletes genre by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            await _genreService.DeleteGenreAsync(id);

            return Ok();
        }
    }
}
