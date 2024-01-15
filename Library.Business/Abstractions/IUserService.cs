using Library.Business.Models.User;
using Library.Business.Models.Utility;

namespace Library.Business.Abstractions
{
    public interface IUserService
    {
        Task<ResponseData<ResponseUserDto?>> GetUserByEmailAsync(string email);
        Task<ResponseData<ResponseUserDto?>> CreateUser(RequestUserDto user);
    }
}
