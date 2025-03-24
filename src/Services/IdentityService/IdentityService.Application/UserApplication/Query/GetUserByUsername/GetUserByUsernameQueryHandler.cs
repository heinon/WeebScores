using IdentityService.Application.UserApplication.Query.GetUserByEmail;
using IdentityService.Infrastructure.Persistence.Repositories;
using SharedKernel.CQRS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.UserApplication.Query.GetUserByUsername;

public class GetUserByUsernameQueryHandler(IUserRepository repository) : IQueryHandler<GetUserByUsernameQuery, UserRecordResponse?>
{
    private readonly IUserRepository _repository = repository;

    public async Task<UserRecordResponse?> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByUsernameAsync(request.Username, cancellationToken);

        if (result is null)
        {
            return null;
        }

        return new UserRecordResponse(result);
    }
}

