using AnimeService.Domain.AnimeAggregate;
using AnimeService.Domain.AnimeAggregate.Entities;
using AnimeService.Domain.AnimeAggregate.ValueObjects;
using AnimeService.Infrastructure.Persistence.Repositories;
using SharedKernel.CQRS.Command;

namespace AnimeService.Application.AnimeApplication.Command.AddAnime;

public class AddAnimeCommandHandler(IAnimeRepository repository) : ICommandHandler<AddAnimeCommand, AnimeResponse>
{
    private readonly IAnimeRepository _repository = repository;
    public async Task<AnimeResponse> Handle(AddAnimeCommand request, CancellationToken cancellationToken)
    {
        var anime = Anime.Create(request.Name, request.Description, request.Status);
        foreach(var episode in request.Episodes)
        {
            anime.AddEpisode(Episode.Create(episode.Title, episode.EpisodeNumber, episode.Description));
        }

        foreach(var genre in request.Genres)
        {
            anime.AddGenre(Genre.Create(genre));
        }

        await _repository.AddAsync(anime, cancellationToken);
        var result = new AnimeResponse(anime.Id.Value);
        return result;
    }
}
