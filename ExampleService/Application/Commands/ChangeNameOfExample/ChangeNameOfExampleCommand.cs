namespace ExampleService.Application.Commands.UpdateNameOfExample;

public class ChangeNameOfExampleCommand : ICommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}