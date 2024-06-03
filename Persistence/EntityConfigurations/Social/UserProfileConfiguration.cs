using Core.Domain.Accounts.Models;
using Core.Domain.UserProfiles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Social;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        var userIdPropertyName = nameof(Friendship.UserId);
        var friendIdPropertyName = nameof(Friendship.FriendId);
        
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

        builder
            .HasMany(u => u.Friends)
            .WithMany()
            .UsingEntity<Friendship>(
                f => f
                    .HasOne(fr => fr.User)
                    .WithMany()
                    .HasForeignKey(fr => fr.UserId),
                f => f
                    .HasOne(fr => fr.Friend)
                    .WithMany()
                    .HasForeignKey(fr => fr.FriendId),
                f =>
                {
                    f.HasKey(fr => new { fr.UserId, fr.FriendId });
                    f.ToTable(tb =>
                        tb.HasCheckConstraint($"CHK_Friendship_{userIdPropertyName}_{friendIdPropertyName}",
                            $"\"{userIdPropertyName}\" != \"{friendIdPropertyName}\""));
                });
    }
}