using Library.Business.Abstractions;
using Library.Business.Models.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

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
    public async Task<IActionResult> GetAuthorsAsync(CancellationToken cancellationToken = default)
    {
        var authors = await _authorService.GetAllAuthorsAsync(cancellationToken);

        return Ok(authors);
    }

    /// <summary>
    /// Returns author by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("id:int")]
    public async Task<IActionResult> GetAuthorByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var author = await _authorService.GetAuthorByIdAsync(id, cancellationToken);

        return Ok(author);
    }

    /// <summary>
    /// Creates author
    /// </summary>
    /// <param name="author"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateAuthorAsync(
        [FromBody] RequestAuthorDto author, CancellationToken cancellationToken = default)
    {
        await _authorService.CreateAuthorAsync(author, cancellationToken);

        return StatusCode(201);
    }

    /// <summary>
    /// Updates author by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="author"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>

    [HttpPut("id:int")]
    public async Task<IActionResult> UpdateAuthorAsync(
        int id, [FromBody] RequestAuthorDto author, CancellationToken cancellationToken = default)
    {
        await _authorService.UpdateAuthorAsync(id, author, cancellationToken);

        return Ok();
    }

    /// <summary>
    /// Deletes author by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("id:int")]
    public async Task<IActionResult> DeleteAuthorAsync(int id, CancellationToken cancellationToken = default)
    {
        await _authorService.DeleteAuthorAsync(id, cancellationToken);

        return StatusCode(204);
    }
}
