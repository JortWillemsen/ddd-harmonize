namespace ExampleService.Infrastructure.Adapters.Database.Postgres;

public class EventEntry
{
    public Guid Id { get; set; }
    public Guid AggregateId { get; set; }
    public string EventType { get; set; }
    public DateTime Timestamp { get; set; }
    public string Data { get; set; }
}