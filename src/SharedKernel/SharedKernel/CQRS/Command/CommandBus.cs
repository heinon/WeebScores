using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace SharedKernel.CQRS.Command;

public class CommandBus(IMediator mediator, ILogger<CommandBus> logger) : ICommandBus
{
    private readonly IMediator _mediator = mediator;
    private readonly ILogger<CommandBus> _logger = logger;

    public Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Sending command: {CommandType}", command.GetType().Name);
        return _mediator.Send(command, cancellationToken);
    }
}
