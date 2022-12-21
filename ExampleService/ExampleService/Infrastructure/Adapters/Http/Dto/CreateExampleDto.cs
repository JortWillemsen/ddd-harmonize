using ExampleService.Application.Commands.CreateExample;

namespace ExampleService.Infrastructure.Adapters.Http.Dto;

public class CreateExampleDto
{
    
}

public static class CreateExampleDtoExtensions
{
    public static CreateExampleCommand ToCommand(this CreateExampleDto dto)
    {
        return new CreateExampleCommand();
    }
}