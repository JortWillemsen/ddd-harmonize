using Common.Exceptions;
using DotnetCute.Exceptions.Http.Client;
using ExampleService.Application.Commands.ChangeNameOfExample;

namespace ExampleService.Domain.BusinessRules;

public static class ExampleRules
{
    public static void NameCannotBeLongerThan10Characters(this ChangeNameOfExampleCommand command)
    {
        if (command.Name.Length > 10)
        {
            throw new NameTooLongException("Name cannot be longer than 10 characters.");
        }
    }
}