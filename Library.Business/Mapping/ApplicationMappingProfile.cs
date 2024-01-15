using AutoMapper;
using Library.Business.Models.Author;
using Library.Business.Models.Book;
using Library.Business.Models.Genre;
using Library.Business.Models.User;
using Library.DataAccess.Models;

namespace Library.Business.Mapping
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Author, ResponseAuthorDto>();
            CreateMap<RequestAuthorDto, Author>();

            CreateMap<Genre, ResponseGenreDto>();
            CreateMap<RequestGenreDto, Genre>();

            CreateMap<User, ResponseUserDto>();
            CreateMap<RequestUserDto, User>();

            CreateMap<Book, ResponseBookDto>();
            CreateMap<RequestBookDto, Book>();
        }
    }
}
