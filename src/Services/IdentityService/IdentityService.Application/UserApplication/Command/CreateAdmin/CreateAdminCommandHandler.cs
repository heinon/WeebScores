using IdentityService.Application.UserApplication.Command.RegisterUser;
using IdentityService.Domain.UserAggregate;
using IdentityService.Infrastructure.Persistence.Repositories;
using SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.UserApplication.Command.CreateAdmin;

public class CreateAdminCommandHandler(IUserRepository repository) : ICommandHandler<CreateAdminCommand, UserResponse>
{
    private readonly IUserRepository _repository = repository;
    public async Task<UserResponse> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        var admin = await _repository.GetByUsernameAsync("adminweeb", cancellationToken);
        if (admin is null)
        {
            var user = User.Create("adminweeb", "Admin", "Weeb", "admin@weebscores.com", "password", "Admin");
            await _repository.AddAsync(user, cancellationToken);
            return new UserResponse(user.Id.Value);
        }

        return new UserResponse(admin.Id.Value);
    }
}
