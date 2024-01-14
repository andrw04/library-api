namespace Library.DataAccess.Models;

public class Genre : Entity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public IEnumerable<Book> Books { get; set; }
}