using Core.Domain.UserProfiles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Contexts;

namespace Persistence.EntityConfigurations.Identity;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        //builder.ToTable("UserProfiles", IdentityDbContext.DbSchema);
        
        builder.HasKey(up => up.AccountId);
    }
}