using MediatR;

namespace SharedKernel.CQRS.Command;

public interface ICommand<TResponse> : IRequest<TResponse>
{
}
