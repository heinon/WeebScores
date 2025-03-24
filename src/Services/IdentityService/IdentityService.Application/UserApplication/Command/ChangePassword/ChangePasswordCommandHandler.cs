using IdentityService.Domain.UserAggregate.ValueObjects;
using IdentityService.Infrastructure.Persistence.Repositories;
using SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.UserApplication.Command.ChangePassword;

public class ChangePasswordCommandHandler(IUserRepository repository) : ICommandHandler<ChangePasswordCommand, UserResponse>
{
    private readonly IUserRepository _repository = repository;
    public async Task<UserResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(UserId.Create(request.UserId), cancellationToken);

        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        user.ChangePassword(request.NewPassword);
        await _repository.UpdateAsync(user, cancellationToken);
        return new UserResponse(user.Id.Value);
    }
}
