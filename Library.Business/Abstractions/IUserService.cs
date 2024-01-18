using Library.Business.Models.User;

namespace Library.Business.Abstractions;

public interface IUserService
{
    Task<ResponseUserDto> GetUserByEmailAsync(string email);
    Task<ResponseUserDto?> CreateUser(RequestUserDto user);
    Task<string> CreateToken(ResponseUserDto user);
}
