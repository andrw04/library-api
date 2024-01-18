using Library.Business.Abstractions;
using Library.Business.Models.User;
using Library.DataAccess.Abstractions;
using AutoMapper;

namespace Library.Business.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<string> CreateToken(ResponseUserDto user)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseUserDto?> CreateUser(RequestUserDto user)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseUserDto> GetUserByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    /*public async Task<ResponseData<ResponseUserDto?>> CreateUser(RequestUserDto requestUser)
    {
        try
        {
            var user = _mapper.Map<User>(requestUser);

            await _unitOfWork.UserRepository.AddAsync(user);

            return new ResponseData<ResponseUserDto?>();
        }
        catch (Exception ex)
        {
            return new ResponseData<ResponseUserDto?>()
            {
                Data = null,
                IsSuccess = false,
                ExceptionData = ex
            };
        }
    }

    public async Task<ResponseData<ResponseUserDto?>> GetUserByEmailAsync(string email)
    {
        try
        {
            var response = (await _unitOfWork.UserRepository.GetAsync(u => u.Email == email));

            if (!response.Any())
                throw new Exception("User is not found");

            return new ResponseData<ResponseUserDto?>()
            {
                Data = _mapper.Map<ResponseUserDto>(response.First())
            };
        }
        catch (Exception ex)
        {
            return new ResponseData<ResponseUserDto?>()
            {
                Data = null,
                IsSuccess = false,
                ExceptionData = ex
            };
        }
    }*/
}
