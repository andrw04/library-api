using Microsoft.AspNetCore.Mvc;
using Library.Business.Models.User;
using Library.Business.Abstractions;

namespace Library.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Creates a new user
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(
        [FromBody] RequestUserDto request, CancellationToken cancellationToken = default)
    {
        await _userService.RegisterAsync(request, cancellationToken);

        return Created();
    }

    /// <summary>
    /// Returns jwt bearer
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody] LoginUserDto user, CancellationToken cancellationToken = default)
    {
        var loggedUser = await _userService.LoginAsync(user, cancellationToken);

        var token = _userService.CreateToken(loggedUser);

        return Ok("Bearer " + token);
    }
}
