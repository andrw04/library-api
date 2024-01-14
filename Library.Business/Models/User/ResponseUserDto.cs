namespace Library.Business.Models.User
{
    public class ResponseUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
