using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.UserAggregate.ValueObjects;

public class Name : ValueObject<Name>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    private Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static Name Create(string firstName, string lastName)
    {
        return new Name(firstName, lastName);
    }

    public void UpdateName(string firstName, string lastName)
    {
        FirstName = FirstName.Trim();
        LastName = LastName.Trim();
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }

    public override string ToString() 
    {
        return LastName + ", " + FirstName;
    }

    public string Initials()
    {
        return $"{FirstName[0].ToString().ToUpper()}.{LastName[0].ToString().ToUpper()}.";
    }
}
