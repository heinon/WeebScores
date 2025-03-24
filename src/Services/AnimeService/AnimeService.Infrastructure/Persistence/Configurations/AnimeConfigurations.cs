using AnimeService.Domain.AnimeAggregate;
using AnimeService.Domain.AnimeAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeService.Infrastructure.Persistence.Configurations;

public class AnimeConfigurations : IEntityTypeConfiguration<Anime>
{
    public void Configure(EntityTypeBuilder<Anime> builder)
    {
        builder.ToTable("Animes");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => AnimeId.Create(value));

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Description)
            .HasMaxLength(255);

        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.OwnsMany(x => x.Genres, g =>
        {
            g.ToTable("Genres");
            g.WithOwner().HasForeignKey("AnimeId");
            g.Property(v => v.Name).IsRequired().HasMaxLength(20);
        });

        builder.OwnsMany(x => x.Episodes, e =>
        {
            e.ToTable("Episodes");
            e.WithOwner().HasForeignKey("AnimeId");
            e.HasKey(v => v.Id);
            e.Property(v => v.Id).ValueGeneratedNever().HasConversion(id => id.Value, value => EpisodeId.Create(value));
            e.Property(v => v.Title).IsRequired().HasMaxLength(50);
            e.Property(v => v.Description).IsRequired().HasMaxLength(50);
            e.Property(v => v.EpisodeNumber).IsRequired().HasMaxLength(4);
        });
    }
}
