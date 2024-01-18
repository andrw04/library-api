namespace Library.Business.Exceptions;

public class IsNotExistsException : ArgumentException
{
    public IsNotExistsException(string entity) : base($"{entity} is not exists.")
    {
        
    }
}
