using Core.Domain.Photos.Enums;
using Core.Domain.Photos.Models.Abstractions;
using Core.Domain.Photos.Models.ConcreteTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Contexts;

namespace Persistence.EntityConfigurations.Media;

public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.ToTable("Photos", MediaDbContext.DbSchema);

        builder
            .HasDiscriminator(p => p.Type)
            .HasValue<AvatarPhoto>(PhotoType.Avatar)
            .HasValue<ProfilePhoto>(PhotoType.Profile)
            .HasValue<PostPhoto>(PhotoType.Post);

        builder
            .HasIndex(p => p.Type);
    }
}