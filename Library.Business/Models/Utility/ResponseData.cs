namespace Library.Business.Models.Utility;

public class ResponseData<T>
{
    public bool IsSuccess { get; set; } = true;
    public Exception? ExceptionData { get; set; } = null!;
    public T? Data { get; set; }
}
