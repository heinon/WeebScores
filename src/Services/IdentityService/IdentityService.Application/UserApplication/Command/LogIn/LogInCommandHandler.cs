using FluentValidation;
using IdentityService.Domain.UserAggregate;
using IdentityService.Infrastructure.Persistence.Repositories;
using SharedKernel.CQRS.Command;
using SharedKernel.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.UserApplication.Command.LogIn;

public class LogInCommandHandler(IUserRepository repository, IJwtTokenService jwtTokenService) : ICommandHandler<LogInCommand, LogInResponse>
{
    private readonly IUserRepository _repository = repository;
    private readonly IJwtTokenService _jwtTokenService = jwtTokenService;
    public async Task<LogInResponse> Handle(LogInCommand request, CancellationToken cancellationToken)
    {
        User? user = null;
        if (!string.IsNullOrEmpty(request.Username))
        {
            user = await _repository.GetByUsernameAsync(request.Username, cancellationToken);
        }
        else if (!string.IsNullOrEmpty(request.Email))
        {
            user = await _repository.GetByEmailAsync(request.Email, cancellationToken);
        }

        if (user is null)
        {
            return new LogInResponse(null, null, "Invalid username or email.", false);
        }

        if (!user.ValidateLogInAttempt())
        {
            return new LogInResponse(null, null, "Account is locked due to multiple failed login attempts. Please try again later.", false);
        }

        var success = user.VerifyPassword(request.Password);

        if (!success)
        {
            return new LogInResponse(null, null, "Wrong password.", false);
        }

        var token = _jwtTokenService.GenerateToken(user.Id.Value, user.Role.ToString());
        return new LogInResponse(token, user.Id.Value, "Success", true);
    }
}
