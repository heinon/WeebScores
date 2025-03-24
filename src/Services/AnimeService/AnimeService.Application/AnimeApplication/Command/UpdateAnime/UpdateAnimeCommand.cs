using AnimeService.Application.AnimeApplication.Command.AddAnime;
using AnimeService.Domain.AnimeAggregate.ValueObjects;
using AnimeService.Domain.Enum;
using SharedKernel.CQRS.Command;

namespace AnimeService.Application.AnimeApplication.Command.UpdateAnime;

public record UpdateAnimeCommand(Guid AnimeId, string Name, string Description, AnimeStatus Status, List<UpdateEpisodeCommand> Episodes, List<string> Genres) : ICommand<UpdateAnimeResponse?>;

public record UpdateEpisodeCommand(string Title, string EpisodeNumber, string Description);