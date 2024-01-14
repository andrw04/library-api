using Library.Business.Abstractions;
using Library.Business.Models.User;
using Library.Business.Models.Utility;
using Library.DataAccess.Abstractions;
using AutoMapper;
using Library.DataAccess.Models;

namespace Library.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseData<ResponseUserDto>> CreateUser(RequestUserDto requestUser)
        {
            try
            {
                var user = _mapper.Map<User>(requestUser);

                await _unitOfWork.Users.AddAsync(user);

                return new ResponseData<ResponseUserDto>()
                { 
                    Message = "Successfully created!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseData<ResponseUserDto>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseData<ResponseUserDto>> GetUserByEmailAsync(string email)
        {
            try
            {
                var response = (await _unitOfWork.Users.GetAsync(u => u.Email == email));

                if (!response.Any())
                    throw new Exception("User is not found");

                return new ResponseData<ResponseUserDto>()
                {
                    Data = _mapper.Map<ResponseUserDto>(response.First())
                };
            }
            catch (Exception ex)
            {
                return new ResponseData<ResponseUserDto>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
