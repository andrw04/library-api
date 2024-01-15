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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var response = await _bookService.GetAllBooks();

            if (response.IsSuccess)
            {
                return Ok(response.Data);
            }

            return NotFound(response.ExceptionData?.Message);
        }

        [AllowAnonymous]
        [HttpGet("id:int")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var response = await _bookService.GetBookById(id);

            if (response.IsSuccess)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.ExceptionData?.Message);
        }

        [AllowAnonymous]
        [HttpGet("isbn")]
        public async Task<IActionResult> GetBookByIsbn(string isbn)
        {
            var response = await _bookService.GetBookByIsbn(isbn);

            if (response.IsSuccess)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.ExceptionData?.Message);
        }

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

            return BadRequest(response.ExceptionData?.Message);
        }

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

            return BadRequest(response.ExceptionData?.Message);
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = await _bookService.DeleteBook(id);

            if (response.IsSuccess)
            {
                return Ok("Book successfully deleted");
            }

            return BadRequest(response.ExceptionData?.Message);
        }
    }
}
