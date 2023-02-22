using Common.Application;
using Common.Events;
using ExampleService.Infrastructure.Ports.Messaging;

namespace ExampleService.Application.Commands;

public abstract class BaseCommandHandler<T> : ICommandHandler<T> where T : ICommand
{
    private readonly IMessagePublisher _publisher;

    protected BaseCommandHandler(IMessagePublisher publisher)
    {
        _publisher = publisher;
    }
    
    public abstract Task Handle(T command);

    protected void PublishEvents(IEnumerable<Event> events)
    {
        foreach (dynamic evt in events)
        { 
            _publisher.PublishEvent(evt);
        }
    }
}