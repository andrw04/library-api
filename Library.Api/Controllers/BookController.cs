using Library.Business.Abstractions;
using Library.Business.Models.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    /// <summary>
    /// Returns all books
    /// </summary>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetBooksAsync(CancellationToken cancellationToken = default)
    {
        return Ok(await _bookService.GetAllBooksAsync(cancellationToken));
    }

    /// <summary>
    /// Returns book by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("id:int")]
    public async Task<IActionResult> GetBookByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return Ok(await _bookService.GetBookByIdAsync(id, cancellationToken));
    }

    /// <summary>
    /// Returns book by ISBN
    /// </summary>
    /// <param name="isbn"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("isbn")]
    public async Task<IActionResult> GetBookByIsbnAsync(string isbn, CancellationToken cancellationToken = default)
    {
        return Ok(await _bookService.GetBookByIsbnAsync(isbn, cancellationToken));
    }

    /// <summary>
    /// Creates new book
    /// </summary>
    /// <param name="book"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateBookAsync(
        [FromBody] RequestBookDto book, CancellationToken cancellationToken = default)
    {
        await _bookService.CreateBookAsync(book, cancellationToken);

        return StatusCode(201);
    }

    /// <summary>
    /// Updates book by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="book"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("id:int")]
    public async Task<IActionResult> UpdateBookAsync(
        int id, [FromBody] RequestBookDto book, CancellationToken cancellationToken = default)
    {
        await _bookService.UpdateBookAsync(id, book, cancellationToken);

        return Ok();
    }

    /// <summary>
    /// Deletes book by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("id:int")]
    public async Task<IActionResult> DeleteBookAsync(int id, CancellationToken cancellationToken = default)
    {
        await _bookService.DeleteBookAsync(id, cancellationToken);

        return StatusCode(204);
    }
}
