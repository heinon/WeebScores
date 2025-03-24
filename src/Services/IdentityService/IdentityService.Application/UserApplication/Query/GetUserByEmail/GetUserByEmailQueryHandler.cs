using IdentityService.Application.UserApplication.Query.GetUserById;
using IdentityService.Domain.UserAggregate.ValueObjects;
using IdentityService.Infrastructure.Persistence.Repositories;
using SharedKernel.CQRS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.UserApplication.Query.GetUserByEmail;

public class GetUserByEmailQueryHandler(IUserRepository repository) : IQueryHandler<GetUserByEmailQuery, UserRecordResponse?>
{
    private readonly IUserRepository _repository = repository;

    public async Task<UserRecordResponse?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByEmailAsync(request.Email, cancellationToken);

        if (result is null)
        {
            return null;
        }

        return new UserRecordResponse(result);
    }
}
