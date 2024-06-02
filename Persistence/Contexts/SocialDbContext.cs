using Core.Domain.PostComments.Models;
using Core.Domain.Posts.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class SocialDbContext(DbContextOptions<SocialDbContext> options) : DbContext(options)
{
    internal const string DbSchema = "Social";
    internal const string DbMigrationsHistoryTable = "__SocialDbMigrationsHistory";

    public DbSet<Post> Posts { get; set; }
    
    public DbSet<PostComment> PostComments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbSchema);
    }
}