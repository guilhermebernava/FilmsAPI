namespace Infra.Exceptions;

public class ApplicationDbException : Exception
{
    public ApplicationDbException(string message) : base(message)
    {
    }
}
