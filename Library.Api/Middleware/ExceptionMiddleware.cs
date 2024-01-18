using FluentValidation;
using FluentValidation.Results;
using Library.Api.Models;
using Microsoft.CodeAnalysis.Options;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol;
using System.Net;
using System.Text.Json;

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
                Message = JsonSerializer.Serialize(e.Errors.Select(err => new
                {
                    Property = err.PropertyName,
                    Value = err.ErrorMessage
                }))
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
