using Library.Business.Abstractions;
using Library.Business.Models.Genre;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

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
    public async Task<IActionResult> GetGenresAsync(CancellationToken cancellationToken = default)
    {
        var genres = await _genreService.GetAllGenresAsync(cancellationToken);

        return Ok(genres);
    }

    /// <summary>
    /// Returns genre by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("id:int")]
    public async Task<IActionResult> GetGenreByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var genre = await _genreService.GetGenreByIdAsync(id, cancellationToken);

        return Ok(genre);
    }

    /// <summary>
    /// Creates new genre
    /// </summary>
    /// <param name="genre"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateGenreAsync(
        [FromBody] RequestGenreDto genre, CancellationToken cancellationToken = default)
    {
        await _genreService.CreateGenreAsync(genre, cancellationToken);

        return StatusCode(201);
    }

    /// <summary>
    /// Updates genre by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="genre"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("id:int")]
    public async Task<IActionResult> UpdateGenreAsync(
        int id, [FromBody] RequestGenreDto genre, CancellationToken cancellationToken = default)
    {
        await _genreService.UpdateGenreAsync(id, genre, cancellationToken);

        return Ok();
    }

    /// <summary>
    /// Deletes genre by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("id:int")]
    public async Task<IActionResult> DeleteGenreAsync(int id, CancellationToken cancellationToken = default)
    {
        await _genreService.DeleteGenreAsync(id, cancellationToken);

        return StatusCode(204);
    }
}
