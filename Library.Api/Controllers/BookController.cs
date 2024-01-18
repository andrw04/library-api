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
    public async Task<IActionResult> GetBooksAsync()
    {
        return Ok(await _bookService.GetAllBooksAsync());
    }

    /// <summary>
    /// Returns book by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("id:int")]
    public async Task<IActionResult> GetBookById(int id)
    {
        return Ok(await _bookService.GetBookByIdAsync(id));
    }

    /// <summary>
    /// Returns book by ISBN
    /// </summary>
    /// <param name="isbn"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("isbn")]
    public async Task<IActionResult> GetBookByIsbn(string isbn)
    {
        return Ok(await _bookService.GetBookByIsbnAsync(isbn));
    }

    /// <summary>
    /// Creates new book
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] RequestBookDto book)
    {
        await _bookService.CreateBookAsync(book);

        return StatusCode(201);
    }

    /// <summary>
    /// Updates book by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="book"></param>
    /// <returns></returns>
    [HttpPut("id:int")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] RequestBookDto book)
    {
        await _bookService.UpdateBookAsync(id, book);

        return Ok();
    }

    /// <summary>
    /// Deletes book by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("id:int")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await _bookService.DeleteBookAsync(id);

        return StatusCode(204);
    }
}
