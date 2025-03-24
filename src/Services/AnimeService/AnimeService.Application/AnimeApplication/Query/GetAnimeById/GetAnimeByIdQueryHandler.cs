using AnimeService.Domain.AnimeAggregate.ValueObjects;
using AnimeService.Infrastructure.Persistence.Repositories;
using SharedKernel.CQRS.Query;

namespace AnimeService.Application.AnimeApplication.Query.GetAnimeById;

public class GetAnimeByTitleQueryHandler(IAnimeRepository repository) : IQueryHandler<GetAnimeByIdQuery, AnimeRecordResponse?>
{
    private readonly IAnimeRepository _repository = repository;
    public async Task<AnimeRecordResponse?> Handle(GetAnimeByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(AnimeId.Create(request.AnimeId), cancellationToken);

        if (result is null)
        {
            return null;
        }

        return new AnimeRecordResponse(result);
    }
}
