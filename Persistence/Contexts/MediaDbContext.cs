using Core.Domain.Photos.Models.ConcreteTypes;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations.Media;

namespace Persistence.Contexts;

public class MediaDbContext(DbContextOptions<MediaDbContext> options) : DbContext(options)
{
    internal const string DbSchema = "Media";
    internal const string DbMigrationsHistoryTable = "__MediaDbMigrationsHistory";

    public DbSet<AvatarPhoto> AvatarPhotos { get; set; }
    
    public DbSet<ProfilePhoto> ProfilePhotos { get; set; }
    
    public DbSet<PostPhoto> PostPhotos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbSchema);

        modelBuilder.ApplyConfiguration(new PhotoConfiguration());
    }
}