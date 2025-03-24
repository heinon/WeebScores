using IdentityService.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.UserApplication;

public record UserResponse(Guid UserId);

public record UserRecordResponse(Guid Id, string UserName, string FullName, string Email, string Role)
{
    public UserRecordResponse(User user)
        : this(
              user.Id.Value,
              user.Username,
              user.Name.ToString(),
              user.Email,
              user.Role.ToString()
              )
    {

    }
}