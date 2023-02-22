namespace Common.Application;

public interface ICommandHandler<in T> where T : ICommand
{
    Task Handle(T command);
}