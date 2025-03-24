using AnimeService.Domain.AnimeAggregate.Entities;
using AnimeService.Domain.AnimeAggregate.ValueObjects;
using AnimeService.Domain.Enum;
using MassTransit.Caching.Internals;
using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AnimeService.Domain.AnimeAggregate;

public class Anime : AggregateRoot<AnimeId>
{
    private readonly List<Episode> _episodes = new();
    private readonly List<Genre> _genres = new();
    public string Name { get; private set; }
    public string Description { get; private set; }
    public AnimeStatus Status { get; private set; }
    public IReadOnlyList<Episode> Episodes => _episodes.AsReadOnly();
    public IReadOnlyList<Genre> Genres => _genres.AsReadOnly();

    private Anime(
        AnimeId id,
        string name,
        string description,
        AnimeStatus status) 
        : base(id)
    {
        Name = name;
        Description = description;
        Status = status;
    }

    public static Anime Create(
        string name,
        string description,
        AnimeStatus status)
    {
        return new Anime(AnimeId.Create(), name, description, status);
    }

    public void UpdateAnime(string name, string description, AnimeStatus status)
    {
        Name = name;
        Description = description;
        Status = status;
    }

    public void AddEpisode(Episode episode)
    {
        _episodes.Add(episode);
    }

    public void UpdateEpisodes(IList<Episode> episodes)
    {
        foreach (var episode in episodes)
        {
            if (!Episodes.Contains(episode))
            {
                this.AddEpisode(episode);
            }
        }

        foreach (var episode in Episodes.ToList())
        {
            if (!episodes.Contains(episode))
            {
                this.RemoveEpisode(episode);
            }
        }
    }

    public void RemoveEpisode(Episode episode)
    {
        _episodes.Remove(episode);
    }

    public void AddGenre(Genre genre)
    {
        _genres.Add(genre);
    }

    public void UpdateGenres(IList<Genre> genres)
    {
        foreach (var episode in genres)
        {
            if (!Genres.Contains(episode))
            {
                this.AddGenre(episode);
            }
        }

        foreach (var genre in Genres.ToList())
        {
            if (!genres.Contains(genre))
            {
                this.RemoveGenre(genre);
            }
        }
    }

    public void RemoveGenre(Genre genre)
    {
        _genres.Remove(genre);
    }
}
