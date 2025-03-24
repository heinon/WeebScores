using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedKernel.Domain;

public abstract class StronglyTypedId<T, TValue> : ValueObject<T> where T : StronglyTypedId<T, TValue>
{
    public TValue? Value { get; private set; }

    public StronglyTypedId(TValue value)
    {
        Value = value;
    }

    public override string? ToString()
    {
        return Value?.ToString();
    }
}
