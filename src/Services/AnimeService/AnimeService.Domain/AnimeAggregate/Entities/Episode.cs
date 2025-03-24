using AnimeService.Domain.AnimeAggregate.ValueObjects;
using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeService.Domain.AnimeAggregate.Entities;

public class Episode : Entity<EpisodeId>
{
    public string Title { get; private set; }
    public string EpisodeNumber { get; private set; }
    public string Description { get; private set; }

    private Episode(EpisodeId id, string title, string episodeNumber, string description) : base(id)
    {
        Title = title;
        EpisodeNumber = episodeNumber;
        Description = description;
    }

    public static Episode Create(string  title, string episodeNumber, string description)
    {
        return new Episode(EpisodeId.Create() ,title, episodeNumber, description);
    }
}
