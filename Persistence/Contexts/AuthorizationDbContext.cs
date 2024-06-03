using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> options) : DbContext(options)
{
    internal const string DbSchema = "Authorization";
    internal const string DbMigrationsHistoryTable = "__AuthorizationDbMigrationsHistory";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbSchema);
    }
}