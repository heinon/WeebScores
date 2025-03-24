using MassTransit;

namespace SharedKernel.CQRS.Command;

public interface ICommandBus
{
    Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);
}
