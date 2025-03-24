using AnimeService.Domain.AnimeAggregate;
using AnimeService.Domain.AnimeAggregate.ValueObjects;

namespace AnimeService.Infrastructure.Persistence.Repositories;

public interface IAnimeRepository
{
    Task<Anime?> GetByIdAsync(AnimeId id, CancellationToken cancellationToken);
    Task<Anime?> GetByTitleAsync(string name, CancellationToken cancellationToken);
    Task<IList<Anime>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Anime anime, CancellationToken cancellationToken);
    Task DeleteAsync(AnimeId id, CancellationToken cancellationToken);
    Task UpdateAsync(Anime anime, CancellationToken cancellationToken);
}
