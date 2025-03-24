using SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.UserApplication.Command.ChangePassword;

public record ChangePasswordCommand(Guid UserId, string NewPassword) : ICommand<UserResponse>;
