using Serilog;

namespace Library.Api.Middleware
{
    public class LoggingMiddleware
    {
        RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);

            var code = context.Response.StatusCode;

            if (code < 200 || code > 299)
            {
                var url = $"{context.Request.Path}";
                Log.Information("---> request {@url} returns {@code}", url, code);
            }
        }
    }
}
