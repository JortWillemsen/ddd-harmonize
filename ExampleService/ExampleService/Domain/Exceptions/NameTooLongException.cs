using DotnetCute.Exceptions;

namespace ExampleService.Domain.Exceptions;

public class NameTooLongException : ResponseException
{
    public NameTooLongException(string description, params string[] additional) : base(description, additional)
    {
    }
}