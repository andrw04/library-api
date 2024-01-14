using Library.Business.Models.User;
using Library.Business.Models.Utility;

namespace Library.Business.Abstractions
{
    public interface IUserService
    {
        Task<ResponseData<ResponseUserDTO>> GetUserByEmailAsync(string email);
        Task<ResponseData<ResponseUserDTO>> CreateUser(RequestUserDTO user);
    }
}
