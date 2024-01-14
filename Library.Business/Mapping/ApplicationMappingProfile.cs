using AutoMapper;
using Library.Business.Models.User;
using Library.DataAccess.Models;

namespace Library.Business.Mapping
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<User, ResponseUserDto>();

            CreateMap<RequestUserDto, User>();
        }
    }
}
