namespace Assigment_Book.Exceptions;

public class InputException: Exception
{
    public InputException()
    {
    }

    public InputException(string message) : base(">> Input exception: " + message)
    {
    }
}