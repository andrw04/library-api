namespace Library.Business.Models.User;

public class LoginUserDto
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}