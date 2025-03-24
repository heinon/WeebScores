using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.UserApplication.Command.LogIn;

public record LogInResponse(string? Token, Guid? UserId, string Message, bool IsSuccess);
