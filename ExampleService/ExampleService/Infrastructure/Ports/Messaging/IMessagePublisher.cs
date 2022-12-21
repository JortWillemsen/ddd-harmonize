using ExampleService.Domain.Events;

namespace ExampleService.Infrastructure.Ports.Messaging;

public interface IMessagePublisher
{
    void PublishEvent(ExampleCreatedEvent evt);
    void PublishEvent(NameChangedEvent evt);
}