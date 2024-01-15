using Library.Api.Middleware;

namespace Library.Api.Extensions
{
    public static class LoggingExtension
    {
        public static IApplicationBuilder UseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
