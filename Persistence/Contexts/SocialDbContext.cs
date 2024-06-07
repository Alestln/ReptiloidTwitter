using Core.Domain.Accounts.Models;
using Core.Domain.Photos.Models;
using Core.Domain.PostComments.Models;
using Core.Domain.Posts.Models;
using Core.Domain.Roles.Models;
using Core.Domain.UserProfiles.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations.Social;

namespace Persistence.Contexts;

public class SocialDbContext(DbContextOptions<SocialDbContext> options) : DbContext(options)
{
    internal const string DbSchema = "Social";
    internal const string DbMigrationsHistoryTable = "__SocialDbMigrationsHistory";
    
    public DbSet<Account> Accounts { get; set; }

    public DbSet<UserProfile> UserProfiles { get; set; }
    
    public DbSet<Photo> Photos { get; set; }
    
    public DbSet<Post> Posts { get; set; }
    
    public DbSet<Role> Roles { get; set; }
    
    public DbSet<RoleAccount> RoleAccount { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbSchema);
        
        modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
        modelBuilder.ApplyConfiguration(new PostConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
    }
}