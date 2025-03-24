using IdentityService.Domain.UserAggregate;
using IdentityService.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => UserId.Create(value));

        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(x => x.Username).IsUnique();

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(x => x.Email).IsUnique();

        builder.OwnsOne(x => x.Name, n =>
        {
            n.Property(n => n.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(20);
            n.Property(n => n.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(20);
        });

        builder.OwnsOne(x => x.Password, p =>
        {
            p.Property(p => p.Salt).HasColumnName("PasswordSalt");
            p.Property(p => p.Hash).HasColumnName("PasswordHash");
        });

        builder.OwnsOne(x => x.Role, r =>
        {
            r.Property(r => r.RoleName).HasColumnName("Role").IsRequired().HasMaxLength(10);
        });

        builder.Property(u => u.Locked)
            .IsRequired();

        builder.Property(u => u.FailedAttempts)
            .IsRequired();

        builder.Property(u => u.LockedUntil)
            .IsRequired(false);
    }
}
