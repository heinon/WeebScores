using AnimeService.Domain.AnimeAggregate;
using AnimeService.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AnimeService.Infrastructure.Persistence;

public class AnimeServiceDbContext : DbContext
{
    public AnimeServiceDbContext(DbContextOptions<AnimeServiceDbContext> options) : base(options)
    {

    }

    public DbSet<Anime> Animes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new AnimeConfigurations());
    }
}
