using SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.UserApplication.Command.RegisterUser;

public record RegisterUserCommand(string Username, string FirstName, string LastName, string Email, string Password, string Role) : ICommand<UserResponse>;