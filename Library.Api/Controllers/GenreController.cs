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
        private readonly IValidator<RequestGenreDto> _validator;
        public GenreController(IGenreService genreService, IValidator<RequestGenreDto> validator)
        {
            _genreService = genreService;
            _validator = validator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            var response = await _genreService.GetAllGenres();

            if (response.IsSuccess)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.ExceptionData?.Message);
        }

        [AllowAnonymous]
        [HttpGet("id:int")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var response = await _genreService.GetGenreById(id);

            if (response.IsSuccess)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.ExceptionData?.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] RequestGenreDto genre)
        {
            var validationResult = _validator.Validate(genre);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _genreService.CreateGenre(genre);

            if (response.IsSuccess)
            {
                return Ok("Genre successfully created");
            }

            return BadRequest(response.ExceptionData?.Message);
        }

        [HttpPut("id:int")]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] RequestGenreDto genre)
        {
            var validationResult = _validator.Validate(genre);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _genreService.UpdateGenre(id, genre);

            if (response.IsSuccess)
            {
                return Ok("Genre successfully updated");
            }

            return BadRequest(response.ExceptionData?.Message);
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var response = await _genreService.DeleteGenre(id);

            if (response.IsSuccess)
            {
                return Ok("Genre successfully deleted");
            }

            return BadRequest(response.ExceptionData?.Message);
        }
    }
}
