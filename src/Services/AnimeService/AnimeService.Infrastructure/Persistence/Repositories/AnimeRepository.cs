using AnimeService.Domain.AnimeAggregate;
using AnimeService.Domain.AnimeAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeService.Infrastructure.Persistence.Repositories;

public class AnimeRepository(AnimeServiceDbContext context) : IAnimeRepository
{
    private readonly AnimeServiceDbContext _context = context;

    public async Task AddAsync(Anime anime, CancellationToken cancellationToken)
    {
        _context.Animes.Add(anime);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(AnimeId id, CancellationToken cancellationToken)
    {
        var anime = await _context.Animes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (anime is not null)
        {
            _context.Animes.Remove(anime);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<IList<Anime>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Animes.Include(x => x.Genres).Include(x => x.Episodes).ToListAsync(cancellationToken);
    }

    public async Task<Anime?> GetByIdAsync(AnimeId id, CancellationToken cancellationToken)
    {
        return await _context.Animes.Include(x => x.Genres).Include(x => x.Episodes).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Anime?> GetByTitleAsync(string name, CancellationToken cancellationToken)
    {
        return await _context.Animes.Include(x => x.Genres).Include(x => x.Episodes).FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
    }

    public async Task UpdateAsync(Anime anime, CancellationToken cancellationToken)
    {
        _context.Animes.Update(anime);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
