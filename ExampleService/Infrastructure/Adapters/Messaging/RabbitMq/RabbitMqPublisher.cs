using Common.Events;
using Common.Events.ExampleService;
using ExampleService.Infrastructure.Ports.Messaging;
using Wrappit.Messaging;

namespace ExampleService.Infrastructure.Adapters.Messaging.RabbitMq;

public class RabbitMqPublisher : IMessagePublisher
{
    private readonly IWrappitPublisher _publisher;

    public RabbitMqPublisher(IWrappitPublisher publisher)
    {
        _publisher = publisher;
    }

    public void PublishEvent(ExampleCreatedEvent evt)
    {
        _publisher.Publish("Example.ExampleCreated", evt);
    }

    public void PublishEvent(NameChangedEvent evt)
    {
        _publisher.Publish("Example.NameChanged", evt);
    }
}