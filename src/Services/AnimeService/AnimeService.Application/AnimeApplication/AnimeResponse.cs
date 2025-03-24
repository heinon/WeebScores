using AnimeService.Domain.AnimeAggregate;
using AnimeService.Domain.AnimeAggregate.ValueObjects;

namespace AnimeService.Application.AnimeApplication;

public record AnimeResponse(Guid Id);

public record AnimeRecordResponse(
    Guid AnimeId,
    string Name,
    string Description,
    string Status,
    List<string> Genres,
    List<EpisodeRecordResponse> Episodes)
{
    public AnimeRecordResponse(Anime anime)
        : this(
            anime.Id.Value,
            anime.Name,
            anime.Description,
            anime.Status.ToString(),
            anime.Genres.Select(g => g.Name).ToList(),
            anime.Episodes.Select(e => new EpisodeRecordResponse(e.Id, e.Title, e.EpisodeNumber, e.Description)).ToList()
        )
    {
    }
}

public record EpisodeRecordResponse(
    EpisodeId EpisodeId,
    string Title,
    string EpisodeNumber,
    string Description);