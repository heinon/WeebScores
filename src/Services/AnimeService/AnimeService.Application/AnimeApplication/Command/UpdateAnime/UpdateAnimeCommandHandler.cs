using AnimeService.Domain.AnimeAggregate;
using AnimeService.Domain.AnimeAggregate.Entities;
using AnimeService.Domain.AnimeAggregate.ValueObjects;
using AnimeService.Infrastructure.Persistence.Repositories;
using SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeService.Application.AnimeApplication.Command.UpdateAnime;

public class UpdateAnimeCommandHandler(IAnimeRepository repository) : ICommandHandler<UpdateAnimeCommand, UpdateAnimeResponse?>
{
    private readonly IAnimeRepository _repository = repository;
    public async Task<UpdateAnimeResponse?> Handle(UpdateAnimeCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(AnimeId.Create(request.AnimeId), cancellationToken);
        if (result is not null)
        {
            result.UpdateAnime(request.Name, request.Description, request.Status);
            result.UpdateEpisodes(request.Episodes.Select(x => Episode.Create(x.Title, x.EpisodeNumber, x.Description)).ToList());
            result.UpdateGenres(request.Genres.Select(x => Genre.Create(x)).ToList());

            await _repository.UpdateAsync(result, cancellationToken);

            return new UpdateAnimeResponse(result.Id.Value);
        }

        return null;
    }
}
