using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.UserAggregate.ValueObjects;

public class Role : ValueObject<Role>
{
    public static readonly Role Admin = new Role("Admin");
    public static readonly Role User = new Role("User");
    public string RoleName {  get; private set; }
    private Role(string roleName)
    {
        RoleName = roleName;
    }

    public static Role Create(string roleName)
    {
        return roleName switch
        {
            "Admin" => Admin,
            "User" => User,
            _ => throw new ArgumentException($"Invalid Role: {roleName}")
        };
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return RoleName;
    }

    public override string ToString()
    {
        return RoleName;
    }
}
