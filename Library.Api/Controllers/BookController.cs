using Library.Business.Abstractions;
using Library.Business.Models.Book;
using Library.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            var books = await _bookService.GetAllBooks();

            if (books.Any())
            {
                return Ok(books);
            }

            return NotFound();
        }

        [HttpGet("id:int")]
        public async Task<ActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetBookById(id);

            if (book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }

        [HttpGet("isbn")]
        public async Task<ActionResult> GetBookByIsbn(string isbn)
        {
            var book = await _bookService.GetBookByIsbn(isbn);

            if (book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook([FromBody] RequestBookDto book)
        {
            await _bookService.CreateBook(book);

            return Ok();
        }

        [HttpPut("id:int")]
        public async Task<ActionResult> UpdateBook(int id, [FromBody] RequestBookDto book)
        {
            await _bookService.UpdateBook(id, book);

            return Ok();
        }

        [HttpDelete("id:int")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBook(id);

            return Ok();
        }
    }
}
