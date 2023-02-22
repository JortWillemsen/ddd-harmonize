using DotnetCute.Exceptions;

namespace Common.Exceptions;

public class NameTooLongException : ResponseException
{
    public NameTooLongException(string description, params string[] additional) : base(description, additional)
    {
    }
}