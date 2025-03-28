﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Security;

public class JwtSettings
{
    public string? Secret { get; set; }
    public string? ValidIssuer { get; set; }
    public int ExpirationMinutes { get; set; }
}
