using System.Text.Json;

namespace Library.Api.Models;

public record class ErrorDetails
{
    public int StatusCode { get; init; }
    public string Message { get; init; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
