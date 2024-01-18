using Library.Business.Abstractions;
using Library.Business.Services;
using Library.DataAccess.Abstractions;
using Library.DataAccess.Repository;

namespace Library.Api.Extensions;

public static class ServicesExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<IAuthorService, AuthorService>();

        return services;
    }
}
