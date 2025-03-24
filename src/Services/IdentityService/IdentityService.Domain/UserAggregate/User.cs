using IdentityService.Domain.UserAggregate.ValueObjects;
using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.UserAggregate;

public class User : AggregateRoot<UserId>
{
    private User(UserId id, string username, Name name, string email, Password password, bool locked, int failedAttempts, DateTime? lockedUntil, Role role) : base(id)
    {
        Username = username;
        Name = name;
        Email = email;
        Password = password;
        Locked = locked;
        FailedAttempts = failedAttempts;
        LockedUntil = lockedUntil;
        Role = role;
    }

    private User()
        : base(UserId.Create())
    {
        Name = Name.Create("Default", "User");
        Username = "admin";
        Email = string.Empty;
        Password = Password.Create("defaultpassword");
        Role = Role.Create("Admin");
        Locked = false;
        FailedAttempts = 0;
        LockedUntil = null;
    }

    public string Username { get; private set; }
    public Name Name { get; private set; }
    public string Email { get; private set; }
    public Password Password { get; private set; }
    public bool Locked { get; private set; }
    public int FailedAttempts { get; private set; }
    public DateTime? LockedUntil { get; private set; }
    public Role Role { get; private set; }

    public static User Create(
        string username,
        string firstName,
        string lastName,
        string email,
        string password,
        string role)
    {
        return new User(UserId.Create(), username, Name.Create(firstName, lastName), email, Password.Create(password), false, 0, null, Role.Create(role));
    }

    public void Update(string firstName, string lastName, string email)
    {
        Name = Name.Create(firstName, lastName);
        Email = email;
    }

    public void ResetSignInFail()
    {
        Locked = false;
        LockedUntil = null;
    }

    public bool VerifyPassword(string password)
    {
        if (Password.Verify(password))
        {
            return true;
        }
        else
        {
            OnSignInFail();
            return false;
        }
    }

    public bool ValidateLogInAttempt()
    {
        CheckForUnlock();

        if (Locked)
        {
            return false;
        }

        return true;
    }

    public void OnSignInFail()
    {
        FailedAttempts++;
        if (FailedAttempts >= 5)
        {
            Locked = true;
            LockedUntil = DateTime.UtcNow.AddMinutes(5);
        }
    }

    public void CheckForUnlock()
    {
        if (Locked && DateTime.Now > LockedUntil)
        {
            LockedUntil = null;
            Locked = false;
        }
        return;
    }

    public void ChangePassword(string password)
    {
        Password = Password.Create(password);
    }
}
