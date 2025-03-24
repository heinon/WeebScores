using MediatR;

namespace SharedKernel.CQRS.Command;

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
{
}
