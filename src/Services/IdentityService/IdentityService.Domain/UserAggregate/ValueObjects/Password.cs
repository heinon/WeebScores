using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.UserAggregate.ValueObjects;

public class Password : ValueObject<Password>
{
    public string Salt { get; private set; }
    public string Hash { get; private set; }

    private Password(string salt, string hash)
    {
        Salt = salt;
        Hash = hash;
    }

    public static Password Create(string password)
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt();
        var hash = BCrypt.Net.BCrypt.HashPassword(password, salt);
        return new Password(salt, hash);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Salt;
        yield return Hash;
    }

    public bool Verify(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, Hash);
    }
}
