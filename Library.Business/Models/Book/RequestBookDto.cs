namespace Library.Business.Models.Book;

public class RequestBookDto
{
    public string Isbn { get; set; } = default!;
    public string Title { get; set; } = default!;
    public int GenreId { get; set; }
    public string? Description { get; set; } = default!;
    public int AuthorId { get; set; }
    public DateTime? Borrowed { get; set; } = default!;
    public DateTime? DueDate { get; set; } = default!;
}
