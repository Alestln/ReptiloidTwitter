using Core.Domain.Accounts.Models;
using Core.Domain.UserProfiles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Social;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder
            .HasKey(u => u.AccountId);

        builder
            .HasOne<Account>(u => u.Account)
            .WithOne()
            .HasForeignKey<UserProfile>(u => u.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(u => u.Avatar)
            .WithMany()
            .HasForeignKey(u => u.AvatarId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}