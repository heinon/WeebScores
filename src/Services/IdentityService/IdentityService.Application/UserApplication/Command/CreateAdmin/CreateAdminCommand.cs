using SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.UserApplication.Command.CreateAdmin;

public record CreateAdminCommand() : ICommand<UserResponse>;