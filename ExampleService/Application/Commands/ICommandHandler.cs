namespace ExampleService.Application.Commands;

public interface ICommandHandler<in T> where T : ICommand
{
    Task Handle(T command);
}