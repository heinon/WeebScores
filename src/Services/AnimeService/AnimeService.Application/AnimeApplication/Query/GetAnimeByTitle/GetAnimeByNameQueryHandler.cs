using AnimeService.Infrastructure.Persistence.Repositories;
using SharedKernel.CQRS.Query;

namespace AnimeService.Application.AnimeApplication.Query.GetAnimeByTitle;

public class GetAnimeByNameQueryHandler(IAnimeRepository repository) : IQueryHandler<GetAnimeByNameQuery, AnimeRecordResponse?>
{
    private readonly IAnimeRepository _repository = repository;
    public async Task<AnimeRecordResponse?> Handle(GetAnimeByNameQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByTitleAsync(request.Name, cancellationToken);

        if (result is null)
        {
            return null;
        }

        return new AnimeRecordResponse(result);
    }
}
