using FluentValidation;
using Library.Business.Abstractions;
using Library.Business.Mapping;
using Library.Business.Models.Author;
using Library.Business.Models.Book;
using Library.Business.Models.Genre;
using Library.Business.Models.User;
using Library.Business.Services;
using Library.Business.Validators.Author;
using Library.Business.Validators.Book;
using Library.Business.Validators.Genre;
using Library.Business.Validators.User;
using Library.DataAccess.Abstractions;
using Library.DataAccess.Repository;

namespace Library.Api.Extensions
{
    public static class DependncyInjectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, EfUnitOfWork>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IAuthorService, AuthorService>();


            services.AddAutoMapper(typeof(ApplicationMappingProfile));


            services.AddTransient<IValidator<RequestUserDto>, RequestUserValidator>();
            services.AddTransient<IValidator<LoginUserDto>, LoginUserValidator>();

            services.AddTransient<IValidator<RequestBookDto>, RequestBookValidator>();

            services.AddTransient<IValidator<RequestAuthorDto>, RequestAuthorValidator>();

            services.AddTransient<IValidator<RequestGenreDto>, RequestGenreValidator>();


            return services;
        }
    }
}
