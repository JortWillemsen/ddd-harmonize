using Common.Application;
using Common.Events;
using ExampleService.Domain;
using ExampleService.Infrastructure.Ports.Database;
using ExampleService.Infrastructure.Ports.Messaging;

namespace ExampleService.Application.Commands.CreateExample;

public class CreateExampleCommandHandler : ICommandHandler<CreateExampleCommand>
{
    private readonly IMessagePublisher _publisher;
    private readonly IExampleRepository _repository;

    public CreateExampleCommandHandler(IMessagePublisher publisher, IExampleRepository repository)
    {
        _publisher = publisher;
        _repository = repository;
    }

    public async Task Handle(CreateExampleCommand command)
    {
        var example = new Example(new ExampleId(Guid.NewGuid()));

        await _repository.Update(example);
        PublishEvents(example.Events);
    }

    private void PublishEvents(IEnumerable<Event> events)
    {
        foreach (dynamic evt in events)
        { 
            _publisher.PublishEvent(evt);
        }
    }
}