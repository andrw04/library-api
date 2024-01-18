using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Library.Business.Models.User;
using Library.Business.Abstractions;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult<ResponseUserDto>> Register(RequestUserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            request.Password = passwordHash;

            var response = await _userService.CreateUser(request);

            if (response.IsSuccess)
            {
                return Ok("User successfully created");
            }

            return BadRequest("Something went wrong...");
        }

        /// <summary>
        /// Returns jwt bearer
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<ResponseUserDto>> Login(LoginUserDto user)
        {
            var response = await _userService.GetUserByEmailAsync(user.Email);

            var existsUser = response.Data;

            bool verified = response.IsSuccess &&
                BCrypt.Net.BCrypt.Verify(user.Password, existsUser?.Password);

            if (!verified)
                return BadRequest("Email or password is wrong");

            string token = CreateToken(response?.Data!);

            return Ok("Bearer " + token);
        }

        private string CreateToken(ResponseUserDto user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("Jwt:Secret").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Username),
            };

            var token = new JwtSecurityToken(
                claims: claims,
                issuer: _configuration.GetSection("Jwt:Issuer").Value!,
                audience: _configuration.GetSection("Jwt:Audience").Value!,
                expires: DateTime.UtcNow.AddMinutes(
                    int.Parse(_configuration.GetSection("Jwt:Expires").Value!)),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
