using ExampleService.Application.Commands.UpdateNameOfExample;
using ExampleService.Domain.Events;
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
        var entity = await _repository.FindByAggregateId(command.Id);
        entity.ChangeName(command);

        await _repository.Update(entity);

        PublishEvents(entity.Events);
    }
}