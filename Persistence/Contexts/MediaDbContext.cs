using Core.Domain.Photos.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class MediaDbContext(DbContextOptions<MediaDbContext> options) : DbContext(options)
{
    internal const string DbSchema = "Media";
    internal const string DbMigrationsHistoryTable = "__MediaDbMigrationsHistory";

    public DbSet<Photo> Photos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbSchema);
    }
}