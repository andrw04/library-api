namespace Library.DataAccess.Models;

public class Author : Entity
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}