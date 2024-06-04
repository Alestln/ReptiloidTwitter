using Core.Domain.Accounts.Models;
using Core.Domain.Roles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Social;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder
            .HasMany(a => a.Roles)
            .WithMany()
            .UsingEntity<RoleAccount>(
                ra => ra
                    .HasOne(r => r.Role)
                    .WithMany()
                    .HasForeignKey(r => r.RoleId),
                ra => ra
                    .HasOne(a => a.Account)
                    .WithMany()
                    .HasForeignKey(a => a.AccountId),
                ra =>
                    ra.HasKey(t => new { t.AccountId, t.RoleId }));
    }
}