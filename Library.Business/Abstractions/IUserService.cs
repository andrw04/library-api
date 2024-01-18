using Library.Business.Models.User;

namespace Library.Business.Abstractions;

public interface IUserService
{
    Task<ResponseUserDto> LoginAsync(LoginUserDto user);
    Task RegisterAsync(RequestUserDto user);
    string CreateToken(ResponseUserDto user);
}
