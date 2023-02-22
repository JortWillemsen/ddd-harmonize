namespace Common.Events.ExampleService;

public class ExampleCreatedEvent : Event
{
    public Guid Id { get; }
    
    public ExampleCreatedEvent(Guid aggregateId) : base(aggregateId)
    {
        Id = aggregateId;
    }
}