using FluentValidation;
using Library.Api.Models;

namespace Library.Api.Middleware;

public class ExceptionMiddleware
{
    RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var details = ex switch
        {
            ArgumentException => new ErrorDetails
            {
                StatusCode = 404,
                Message = ex.Message
            },
            ValidationException e => new ErrorDetails
            {
                StatusCode = 404,
                Message = string.Join(' ', e.Errors.Select(err => err.ErrorMessage).ToArray())
            },
            _ => new ErrorDetails
            {
                StatusCode = 500,
                Message = ex.Message
            }
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = details.StatusCode;

        await context.Response.WriteAsync(details.ToString());

    }
}
