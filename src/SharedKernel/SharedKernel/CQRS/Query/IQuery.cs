using MediatR;

namespace SharedKernel.CQRS.Query;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}
