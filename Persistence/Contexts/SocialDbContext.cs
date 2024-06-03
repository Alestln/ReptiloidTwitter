using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class SocialDbContext(DbContextOptions<SocialDbContext> options) : DbContext(options)
{
    internal const string DbSchema = "Social";
    internal const string DbMigrationsHistoryTable = "__SocialDbMigrationsHistory";
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbSchema);
    }
}