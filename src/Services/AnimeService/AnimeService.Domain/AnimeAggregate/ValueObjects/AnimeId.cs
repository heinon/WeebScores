using MassTransit.Caching.Internals;
using SharedKernel.Domain;

namespace AnimeService.Domain.AnimeAggregate.ValueObjects;

public class AnimeId : StronglyTypedId<AnimeId, Guid>
{
    private AnimeId(Guid value) : base(value)
    {
    }

    public static AnimeId Create()
    {
        return new AnimeId(Guid.NewGuid());
    }

    public static AnimeId Create(Guid id)
    {
        return new AnimeId(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
