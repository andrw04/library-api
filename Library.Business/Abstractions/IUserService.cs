using Library.Business.Models.User;

namespace Library.Business.Abstractions;

public interface IUserService
{
    Task<ResponseUserDto> LoginAsync(LoginUserDto user, CancellationToken cancellationToken = default);
    Task RegisterAsync(RequestUserDto user, CancellationToken cancellationToken = default);
    string CreateToken(ResponseUserDto user);
}
