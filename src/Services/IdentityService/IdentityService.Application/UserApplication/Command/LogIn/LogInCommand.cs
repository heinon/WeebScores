using SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IdentityService.Application.UserApplication.Command.LogIn;

public record LogInCommand(string Username, string Email, string Password) : ICommand<LogInResponse>;
