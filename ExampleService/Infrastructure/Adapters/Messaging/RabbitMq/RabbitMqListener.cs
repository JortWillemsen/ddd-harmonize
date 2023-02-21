using System.Text.Json;
using ExampleService.Infrastructure.Adapters.Messaging.Events.Incoming;
using ExampleService.Infrastructure.Ports.Messaging;
using Wrappit.Attributes;

namespace ExampleService.Infrastructure.Adapters.Messaging.RabbitMq;

[EventListener]
public class RabbitMqListener : IMessageListener
{
    private readonly ILogger<RabbitMqListener> _logger;

    public RabbitMqListener(ILogger<RabbitMqListener> logger)
    {
        _logger = logger;
    }

    [Handle("Example.SomethingHappened")]
    public void OnSomethingHappened(OtherServiceSomethingHappenedEvent @event)
    {
        _logger.LogInformation("OtherServiceSomethingHappenedEvent ontvangen: {0}", JsonSerializer.Serialize(@event));
        
    }
}