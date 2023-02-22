using System.Text.Json;
using Common.Events;
using DotnetCute.Exceptions;

namespace Common.Infrastructure.Database;

public abstract class BaseRepository
{
    protected EventEntry SerializeEvent(Event evt)
    {
        var entry = new EventEntry
        {
            Id = evt.Id,
            AggregateId = evt.AggregateId,
            Timestamp = evt.Timestamp,
            EventType = evt.GetType().FullName!,
            Data = JsonSerializer.Serialize(evt, evt.GetType())
        };

        return entry;
    }

    protected IEnumerable<EventEntry> SerializeEvents(IEnumerable<Event> events)
    {
        return events.Select(SerializeEvent);
        
    }

    protected Event DeserializeEvent(EventEntry entry)
    {
        var type = Type.GetType(entry.EventType);

        if (JsonSerializer.Deserialize(entry.Data, type) is not Event deserialized)
        {
            throw new EventCastException("Could not deserialize an event");
        }

        return deserialized;
    }

    protected IEnumerable<Event> DeserializeEvents(IEnumerable<EventEntry> entries)
    {
        return entries.Select(DeserializeEvent);
    }
}

public class EventCastException : ResponseException
{
    public EventCastException(string description, params string[] additional) : base(description, additional)
    {
    }
}