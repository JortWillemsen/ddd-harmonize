using Common.Application;

namespace ExampleService.Application.Commands.ChangeNameOfExample;

public class ChangeNameOfExampleCommand : ICommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}