﻿using FluentValidation;
using Library.Business.Abstractions;
using Library.Business.Models.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IValidator<RequestAuthorDto> _validator;
        public AuthorController(IAuthorService authorService, IValidator<RequestAuthorDto> validator)
        {
            _validator = validator;
            _authorService = authorService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAuthors()
        {
            var response = await _authorService.GetAllAuthors();

            if (response.IsSuccess)
            {
                return Ok(response.Data);
            }

            return NotFound(response.ExceptionData?.Message);
        }

        [AllowAnonymous]
        [HttpGet("id:int")]
        public async Task<ActionResult> GetAuthorById(int id)
        {
            var response = await _authorService.GetAuthorById(id);

            if (response.IsSuccess)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.ExceptionData?.Message);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAuthor([FromBody] RequestAuthorDto author)
        {
            var validationResult = _validator.Validate(author);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _authorService.CreateAuthor(author);

            if (response.IsSuccess)
            {
                return Ok("Author successfully created");
            }

            return BadRequest(response.ExceptionData?.Message);
        }

        [HttpPut("id:int")]
        public async Task<ActionResult> UpdateAuthor(int id, [FromBody] RequestAuthorDto author)
        {
            var validationResult = _validator.Validate(author);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _authorService.UpdateAuthor(id, author);

            if (response.IsSuccess)
            {
                return Ok("Author successfully updated");
            }

            return BadRequest(response.ExceptionData?.Message);
        }

        [HttpDelete("id:int")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            var response = await _authorService.DeleteAuthor(id);

            if (response.IsSuccess)
            {
                return Ok("Author successfully deleted");
            }

            return BadRequest(response.ExceptionData?.Message);
        }
    }
}
