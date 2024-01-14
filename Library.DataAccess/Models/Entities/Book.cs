namespace Library.DataAccess.Models;

public class Book : Entity
{
    public string Isbn { get; set; } = default!;
    public string Title { get; set; } = default!;
    public int GenreId { get; set; }
    public Genre Genre { get; set; } = default!;
    public string? Description { get; set; } = default!;
    public int AuthorId { get; set; }
    public Author Author { get; set; } = default!;
    public DateTime? Borrowed { get; set; } = default!;
    public DateTime? DueDate { get; set; } = default!;
}

