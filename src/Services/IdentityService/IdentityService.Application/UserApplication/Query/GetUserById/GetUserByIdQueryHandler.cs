using IdentityService.Domain.UserAggregate.ValueObjects;
using IdentityService.Infrastructure.Persistence.Repositories;
using SharedKernel.CQRS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.UserApplication.Query.GetUserById;

public class GetUserByIdQueryHandler(IUserRepository repository) : IQueryHandler<GetUserByIdQuery, UserRecordResponse?>
{
    private readonly IUserRepository _repository = repository;

    public async Task<UserRecordResponse?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(UserId.Create(request.UserId), cancellationToken);

        if (result is null)
        {
            return null;
        }

        return new UserRecordResponse(result);
    }
}
