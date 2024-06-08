using Core.Domain.Accounts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Social;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder
            .HasKey(r => r.Token);

        builder
            .HasOne(r => r.Account)
            .WithMany()
            .HasForeignKey(r => r.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}