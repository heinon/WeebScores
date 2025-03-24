﻿using SharedKernel.CQRS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.UserApplication.Query.GetUserById;

public record GetUserByIdQuery(Guid UserId) : IQuery<UserRecordResponse?>;
