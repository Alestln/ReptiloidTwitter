using Core.Domain.Accounts.Models;
using Core.Domain.UserProfiles.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations.Identity;

namespace Persistence.Contexts;

public class IdentityDbContext(DbContextOptions<IdentityDbContext> options) : DbContext(options)
{
    internal const string DbSchema = "Identity";
    internal const string DbMigrationsHistoryTable = "__IdentityDbMigrationsHistory";

    public DbSet<Account> Accounts { get; set; }
    
    public DbSet<UserProfile> UserProfiles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbSchema);

        modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
    }
}