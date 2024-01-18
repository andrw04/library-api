using Library.Api.Middleware;

namespace Library.Api.Extensions;

public static class ExceptionMiddlewareExtension
{
    public static IApplicationBuilder UseCustomExcetionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}
