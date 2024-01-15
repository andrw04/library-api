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
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IAuthorService, AuthorService>();


            services.AddAutoMapper(typeof(ApplicationMappingProfile));


            services.AddScoped<IValidator<RequestUserDto>, RequestUserValidator>();
            services.AddScoped<IValidator<LoginUserDto>, LoginUserValidator>();

            services.AddScoped<IValidator<RequestBookDto>, RequestBookValidator>();

            services.AddScoped<IValidator<RequestAuthorDto>, RequestAuthorValidator>();

            services.AddScoped<IValidator<RequestGenreDto>, RequestGenreValidator>();


            return services;
        }
    }
}
