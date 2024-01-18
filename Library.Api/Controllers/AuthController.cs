using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Library.Business.Models.User;
using Library.Business.Abstractions;

namespace Library.Api.Controllers;

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
    public async Task<IActionResult> RegisterAsync([FromBody] RequestUserDto request)
    {
        await _userService.RegisterAsync(request);

        return Created();
    }

    /// <summary>
    /// Returns jwt bearer
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto user)
    {
        var loggedUser = await _userService.LoginAsync(user);

        var token = _userService.CreateToken(loggedUser);

        return Ok("Bearer " + token);
    }
}
