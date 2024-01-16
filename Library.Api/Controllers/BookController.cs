using FluentValidation;
using Library.Business.Abstractions;
using Library.Business.Models.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IValidator<RequestBookDto> _validator;
        public BookController(IBookService bookService, IValidator<RequestBookDto> validator)
        {
            _bookService = bookService;
            _validator = validator;
        }

        /// <summary>
        /// Returns all books
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var response = await _bookService.GetAllBooks();

            if (response.IsSuccess)
            {
                return response.Data != null ? Ok(response.Data) : NotFound();
            }

            return NotFound("Something went wrong...");
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
            var response = await _bookService.GetBookById(id);

            if (response.IsSuccess)
            {
                return response.Data != null ? Ok(response.Data) : NotFound();
            }

            return BadRequest("Something went wrong...");
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
            var response = await _bookService.GetBookByIsbn(isbn);

            if (response.IsSuccess)
            {
                return response.Data != null ? Ok(response.Data) : NotFound();
            }

            return BadRequest("Something went wrong...");
        }

        /// <summary>
        /// Creates new book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] RequestBookDto book)
        {
            var validationResult = _validator.Validate(book);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _bookService.CreateBook(book);

            if (response.IsSuccess)
            {
                return Ok("Book successfully created");
            }

            return BadRequest("Something went wrong...");
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
            var validationResult = _validator.Validate(book);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _bookService.UpdateBook(id, book);

            if (response.IsSuccess)
            {
                return Ok("Book successfully updated");
            }

            return BadRequest("Something went wrong...");
        }

        /// <summary>
        /// Deletes book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = await _bookService.DeleteBook(id);

            if (response.IsSuccess)
            {
                return Ok("Book successfully deleted");
            }

            return BadRequest("Something went wrong...");
        }
    }
}
