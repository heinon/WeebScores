using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeService.Domain.AnimeAggregate.ValueObjects;

public class Genre : ValueObject<Genre>
{
    public string Name { get; }

    private Genre(string name)
    {
        Name = name;
    }

    public static Genre Create(string name)
    {
        return new Genre(name);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}