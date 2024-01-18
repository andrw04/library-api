namespace Library.Business.Exceptions;

public class AlreadyExistsException : ArgumentException
{
    public AlreadyExistsException(string entity) : base($"This {entity} already exists.")
    { 

    }
}
