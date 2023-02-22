using System.Reflection.Metadata;
using Common.Domain;
using Common.Events;
using Common.Events.ExampleService;
using ExampleService.Application.Commands.ChangeNameOfExample;
using ExampleService.Domain.BusinessRules;
using Wrappit.Messaging;

namespace ExampleService.Domain;

public class Example : AggregateRoot<ExampleId>
{
    public string Name { get; set; }
    
    public Example(ExampleId id) : base(id)
    {
        RaiseEvent(new ExampleCreatedEvent(Id.Value));
    }
    public Example(ExampleId id, IEnumerable<Event> events) : base(id, events) { }

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
        Id = new ExampleId(evt.AggregateId);
    }

    private void Handle(NameChangedEvent evt)
    {
        Name = evt.Name;
    }
}