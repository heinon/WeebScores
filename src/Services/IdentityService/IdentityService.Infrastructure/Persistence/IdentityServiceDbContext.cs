using IdentityService.Domain.UserAggregate;
using IdentityService.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Infrastructure.Persistence;

public class IdentityServiceDbContext : DbContext
{
    public IdentityServiceDbContext(DbContextOptions<IdentityServiceDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfigurations());
    }
}
