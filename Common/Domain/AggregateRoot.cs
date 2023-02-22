using Common.Events;

namespace Common.Domain;

/// <summary>
/// Thanks to @EdwinVW on Github for this implementation
/// https://github.com/EdwinVW/pitstop/blob/main/src/WorkshopManagementAPI/Domain/Core/AggregateRoot.cs
/// </summary>
/// <typeparam name="TId"></typeparam>
public abstract class AggregateRoot<TId> : Entity<TId> where TId: Id
{
    public readonly ICollection<Event> Events;

    protected AggregateRoot(TId id) : base(id)
    {
        Events = new List<Event>();
    }

    protected AggregateRoot(TId id, IEnumerable<Event> events) : base(id)
    {
        Events = new List<Event>();
        foreach (var evt in events)
        {
            When(evt);
        }
    }

    protected void RaiseEvent(Event evt)
    {
        When(evt);
        
        Events.Add(evt);
    }

    protected abstract void When(dynamic evt);
}