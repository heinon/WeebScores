using AnimeService.Domain.Enum;
using SharedKernel.CQRS.Command;

namespace AnimeService.Application.AnimeApplication.Command.AddAnime;

public record AddAnimeCommand(string Name, string Description, AnimeStatus Status, List<AddEpisodeCommand> Episodes, List<string> Genres) : ICommand<AnimeResponse>;

public record AddEpisodeCommand(string Title, string EpisodeNumber, string Description);