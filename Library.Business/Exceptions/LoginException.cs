namespace Library.Business.Exceptions;

public class LoginException : ArgumentException
{
    public LoginException() : base("Email or password is wrong.")
    {
        
    }
}
