namespace Library.Business.Models.Utility
{
    public class ResponseData<T>
    {
        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
