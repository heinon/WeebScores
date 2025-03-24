using IdentityService.Domain.UserAggregate;
using IdentityService.Infrastructure.Persistence.Repositories;
using SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.UserApplication.Command.RegisterUser;

public class RegisterUserCommandHandler(IUserRepository repository) : ICommandHandler<RegisterUserCommand, UserResponse>
{
    private readonly IUserRepository _repository = repository;
    public async Task<UserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(request.Username, request.FirstName, request.LastName, request.Email, request.Password, request.Role);
        await _repository.AddAsync(user, cancellationToken);
        return new UserResponse(user.Id.Value);
    }
}
