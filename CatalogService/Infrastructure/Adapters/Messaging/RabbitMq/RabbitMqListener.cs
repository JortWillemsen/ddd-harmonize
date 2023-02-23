using LibraryService.Infrastructure.Ports.Messaging;
using Wrappit.Attributes;

namespace LibraryService.Infrastructure.Adapters.Messaging.RabbitMq;

[EventListener]
public class RabbitMqListener : IMessageListener
{
    private readonly ILogger<RabbitMqListener> _logger;

    public RabbitMqListener(ILogger<RabbitMqListener> logger)
    {
        _logger = logger;
    }
}