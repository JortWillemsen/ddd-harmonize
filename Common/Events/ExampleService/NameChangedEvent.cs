using Common.Domain;

namespace Common.Events.ExampleService;

public class NameChangedEvent : Event
{
    public  string Name { get; set; }
    
    public NameChangedEvent(Guid aggregateId, string name) : base(aggregateId)
    {
        Name = name;
    }
}