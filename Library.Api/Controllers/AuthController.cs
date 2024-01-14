using BCrypt.Net;
using Library.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Library.DataAccess.Models;
using Library.Business.Models.User;
using Library.Business.Abstractions;
using FluentValidation;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IValidator<RequestUserDTO> _validator;

        public AuthController(
            IConfiguration configuration,
            IUserService userService,
            IValidator<RequestUserDTO> validator)
        {
            _configuration = configuration;
            _userService = userService;
            _validator = validator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ResponseUserDTO>> Register(RequestUserDTO request)
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            request.Password = passwordHash;

            var response = await _userService.CreateUser(request);

            if (response.IsSuccess)
            {
                return Ok("User successfully created");
            }

            return BadRequest(response.Message);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseUserDTO>> Login(RequestUserDTO request)
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _userService.GetUserByEmailAsync(request.Email);

            var existsUser = response.Data;

            bool verified = existsUser != null &&
                request.Username == existsUser.Username &&
                BCrypt.Net.BCrypt.Verify(request.Password, existsUser.Password);

            if (!verified)
                return BadRequest("Username or password is wrong");

            string token = CreateToken(response?.Data!);

            return Ok(token);
        }

        private string CreateToken(ResponseUserDTO user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("Jwt:Secret").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Username),
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    int.Parse(_configuration.GetSection("Jwt:Expires").Value!)),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
