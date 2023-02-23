using System.Reflection.Metadata;
using Common.Domain;
using Common.Events;
using Common.Events.ExampleService;
using ExampleService.Application.Commands.ChangeNameOfExample;
using ExampleService.Domain.BusinessRules;
using Wrappit.Messaging;

namespace ExampleService.Domain;

public class ExampleEntityId : EntityId
{
    public ExampleEntityId(Guid value) : base(value) { }
}

public class Example : AggregateRoot<ExampleEntityId>
{
    public string Name { get; set; }
    
    public Example(ExampleEntityId entityId) : base(entityId)
    {
        RaiseEvent(new ExampleCreatedEvent(Id.Value));
    }
    public Example(ExampleEntityId entityId, IEnumerable<Event> events) : base(entityId, events) { }

    public void ChangeName(ChangeNameOfExampleCommand command)
    {
        command.NameCannotBeLongerThan10Characters();
        
        RaiseEvent(new NameChangedEvent(Id.Value, command.Name));
    }

    protected override void When(dynamic evt)
    {
        Handle(evt);
    }

    private void Handle(ExampleCreatedEvent evt)
    {
        Id = new ExampleEntityId(evt.AggregateId);
    }

    private void Handle(NameChangedEvent evt)
    {
        Name = evt.Name;
    }
}
