using FluentValidation;
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
        public async Task<IActionResult> GetGenres()
        {
            var response = await _genreService.GetAllGenres();

            if (response.IsSuccess)
            {
                return response.Data != null ? Ok(response.Data) : NotFound();
            }

            return BadRequest("Something went wrong...");
        }

        /// <summary>
        /// Returns genre by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("id:int")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var response = await _genreService.GetGenreById(id);

            if (response.IsSuccess)
            {
                return response.Data != null ? Ok(response.Data) : NotFound();
            }

            return BadRequest("Something went wrong...");
        }

        /// <summary>
        /// Creates new genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] RequestGenreDto genre)
        {
            var response = await _genreService.CreateGenre(genre);

            if (response.IsSuccess)
            {
                return Ok("Genre successfully created");
            }

            return BadRequest("Something went wrong...");
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
            var response = await _genreService.UpdateGenre(id, genre);

            if (response.IsSuccess)
            {
                return Ok("Genre successfully updated");
            }

            return BadRequest("Something went wrong...");
        }

        /// <summary>
        /// Deletes genre by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var response = await _genreService.DeleteGenre(id);

            if (response.IsSuccess)
            {
                return Ok("Genre successfully deleted");
            }

            return BadRequest("Something went wrong...");
        }
    }
}
