using Common.Events;

namespace Common.Domain;

public abstract class AggregateRoot
{
    public ICollection<Event> Events = new List<Event>();
    
    public AggregateRoot() {}
    public AggregateRoot(IEnumerable<Event> events)
    {
        foreach (dynamic evt in events)
        {
            When(evt);
        }
    }

    protected abstract void When(dynamic evt);
}