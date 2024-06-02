using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class IdentityDbContext(DbContextOptions<IdentityDbContext> options) : DbContext(options)
{
    internal const string DbSchema = "Identity";
    internal const string DbMigrationsHistoryTable = "__IdentityDbMigrationsHistory";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbSchema);
    }
}