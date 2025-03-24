using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeService.Domain.AnimeAggregate.ValueObjects;

public class EpisodeId : StronglyTypedId<EpisodeId, Guid>
{
    private EpisodeId(Guid value) : base(value)
    {
    }

    public static EpisodeId Create()
    {
        return new EpisodeId(Guid.NewGuid());
    }
    public static EpisodeId Create(Guid id)
    {
        return new EpisodeId(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

