using LibraryService.Infrastructure.Ports.Messaging;
using Wrappit.Messaging;

namespace LibraryService.Infrastructure.Adapters.Messaging.RabbitMq;

public class RabbitMqPublisher : IMessagePublisher
{
    private readonly IWrappitPublisher _publisher;

    public RabbitMqPublisher(IWrappitPublisher publisher)
    {
        _publisher = publisher;
    }
}