using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
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
        private readonly IValidator<RequestUserDto> _registerValidator;
        private readonly IValidator<LoginUserDto> _loginValidator;

        public AuthController(
            IConfiguration configuration,
            IUserService userService,
            IValidator<RequestUserDto> regValidator,
            IValidator<LoginUserDto> logValidator)
        {
            _configuration = configuration;
            _userService = userService;
            _registerValidator = regValidator;
            _loginValidator = logValidator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ResponseUserDto>> Register(RequestUserDto request)
        {
            var validationResult = _registerValidator.Validate(request);

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
        public async Task<ActionResult<ResponseUserDto>> Login(LoginUserDto user)
        {
            var validationResult = _loginValidator.Validate(user);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _userService.GetUserByEmailAsync(user.Email);

            var existsUser = response.Data;

            bool verified = existsUser != null &&
                BCrypt.Net.BCrypt.Verify(user.Password, existsUser.Password);

            if (!verified)
                return BadRequest("Email or password is wrong");

            string token = CreateToken(response?.Data!);

            return Ok(token);
        }

        private string CreateToken(ResponseUserDto user)
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
