using Common.Domain;

namespace Common.Events.ExampleService;

public class ExampleCreatedEvent : Event
{
    public ExampleCreatedEvent(Guid aggregateId) : base(aggregateId) { }
}