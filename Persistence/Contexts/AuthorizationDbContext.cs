using Core.Domain.Roles.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations.Authorization;

namespace Persistence.Contexts;

public class AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> options) : DbContext(options)
{
    internal const string DbSchema = "Authorization";
    internal const string DbMigrationsHistoryTable = "__AuthorizationDbMigrationsHistory";

    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbSchema);

        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
}