using Common.Application;
using Common.Events;
using ExampleService.Domain;
using ExampleService.Infrastructure.Ports.Database;
using ExampleService.Infrastructure.Ports.Messaging;

namespace ExampleService.Application.Commands.ChangeNameOfExample;

public class ChangeNameOfExampleCommandHandler : BaseCommandHandler<ChangeNameOfExampleCommand>
{
    private readonly IExampleRepository _repository;

    public ChangeNameOfExampleCommandHandler(
        IMessagePublisher publisher, 
        IExampleRepository repository)
    : base(publisher) 
    {
        _repository = repository;
    }

    public override async Task Handle(ChangeNameOfExampleCommand command)
    {
        var entity = await _repository.FindByAggregateId(new ExampleId(command.Id));
        entity.ChangeName(command);

        await _repository.Update(entity);

        PublishEvents(entity.Events);
    }
}