using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.UserAggregate.ValueObjects;

public class UserId : StronglyTypedId<UserId, Guid>
{
    private UserId(Guid value) : base(value)
    {
    }

    public static UserId Create()
    {
        return new UserId(Guid.NewGuid());
    }

    public static UserId Create(Guid id)
    {
        return new UserId(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
