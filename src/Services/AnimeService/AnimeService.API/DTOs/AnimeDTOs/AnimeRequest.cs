using AnimeService.Application.AnimeApplication.Command.UpdateAnime;
using AnimeService.Domain.Enum;

namespace AnimeService.API.DTOs.AnimeDTOs;

public record AnimeRequest(string Name, string Description, AnimeStatus Status, List<EpisodeRequest> Episodes, List<string> Genres);

public record EpisodeRequest(string Title, string EpisodeNumber, string Description);
