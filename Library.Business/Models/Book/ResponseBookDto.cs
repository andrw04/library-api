using Library.Business.Models.Author;
using Library.Business.Models.Genre;

namespace Library.Business.Models.Book;

public class ResponseBookDto
{
    public int Id { get; set; } = default!;
    public string ISBN { get; set; } = default!;
    public string Title { get; set; } = default!;
    public ResponseGenreDto Genre { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ResponseAuthorDto Author { get; set; } = default!;
    public DateTime? Borrowed { get; set; } = default!;
    public DateTime? DueDate { get; set; } = default!;
}
