namespace Lab_1.Exceptions;

public class OutOfCardsExceptions : Exception
{
    public OutOfCardsExceptions(string? message) : base(message)
    {
    }

    public OutOfCardsExceptions()
    {
    }
}