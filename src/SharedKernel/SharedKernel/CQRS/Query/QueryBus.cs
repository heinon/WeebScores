using MediatR;
using Microsoft.Extensions.Logging;

namespace SharedKernel.CQRS.Query;

public class QueryBus(IMediator mediator, ILogger<QueryBus> logger) : IQueryBus
{
    private readonly IMediator _mediator = mediator;
    private readonly ILogger<QueryBus> _logger = logger;
    public Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Executing query: {query}", query);
        return _mediator.Send(query, cancellationToken);
    }
}
