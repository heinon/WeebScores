using MassTransit;
using MassTransit.Middleware;
using MassTransit.Transports;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Event;

public class EventBus(IPublishEndpoint publishEndpoint, ISendEndpointProvider sendEndpointProvider, ILogger<EventBus> logger) : IEventBus
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;
    private readonly ILogger<EventBus> _logger = logger;

    public async Task PublishAsync<T>(T eventData, CancellationToken cancellationToken = default) where T : class
    {
        _logger.LogInformation("Publishing event: {EventType}", typeof(T).Name);
        await _publishEndpoint.Publish(eventData, cancellationToken);
        _logger.LogInformation("Event {EventType} published successfully.", typeof(T).Name);
    }

    public async Task SendAsync<T>(T eventData, CancellationToken cancellationToken = default) where T : class
    {
        var queueName = $"queue:{typeof(T).Name}";
        var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri(queueName));
        _logger.LogInformation("Sending event {EventType} to {QueueName}", typeof(T).Name, queueName);
        await endpoint.Send(eventData, cancellationToken);
        _logger.LogInformation("Event {EventType} successfully sent to {QueueName}", typeof(T).Name, queueName);
    }
}
