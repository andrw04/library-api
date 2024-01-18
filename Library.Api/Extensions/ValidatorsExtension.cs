using FluentValidation;
using Library.Business.Models.Author;
using Library.Business.Models.Book;
using Library.Business.Models.Genre;
using Library.Business.Models.User;
using Library.Business.Validators.Author;
using Library.Business.Validators.Book;
using Library.Business.Validators.Genre;
using Library.Business.Validators.User;

namespace Library.Api.Extensions;

public static class ValidatorsExtension
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RequestUserDto>, RequestUserValidator>();
        services.AddScoped<IValidator<LoginUserDto>, LoginUserValidator>();

        services.AddScoped<IValidator<RequestBookDto>, RequestBookValidator>();

        services.AddScoped<IValidator<RequestAuthorDto>, RequestAuthorValidator>();

        services.AddScoped<IValidator<RequestGenreDto>, RequestGenreValidator>();

        return services;
    }
}
