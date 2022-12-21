namespace ExampleService.Domain.Events;

public class ExampleCreatedEvent : Event
{
    public Guid Id { get; }
    
    public ExampleCreatedEvent(Guid aggregateId) : base(aggregateId)
    {
        Id = aggregateId;
    }
}