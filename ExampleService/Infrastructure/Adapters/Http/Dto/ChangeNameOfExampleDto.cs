using ExampleService.Application.Commands.ChangeNameOfExample;

namespace ExampleService.Infrastructure.Adapters.Http.Dto;

public class ChangeNameOfExampleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public static class ChangeNameOfExampleExtensions
{
    public static ChangeNameOfExampleCommand ToCommand(this ChangeNameOfExampleDto dto)
    {
        return new ChangeNameOfExampleCommand { Id = dto.Id, Name = dto.Name };
    }
}