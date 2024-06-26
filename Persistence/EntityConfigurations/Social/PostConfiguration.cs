﻿using Core.Domain.Posts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.Social;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder
            .HasMany(p => p.Likes)
            .WithMany()
            .UsingEntity<PostLike>(
                pl => pl
                    .HasOne(p => p.User)
                    .WithMany()
                    .HasForeignKey(p => p.UserId),
                pl => pl
                    .HasOne(p => p.Post)
                    .WithMany()
                    .HasForeignKey(p => p.PostId),
                pl =>
                    pl.HasKey(p => new { p.UserId, p.PostId }));

        builder
            .HasMany(p => p.Photos)
            .WithMany()
            .UsingEntity<PostPhoto>(
                pp => pp
                    .HasOne(p => p.Photo)
                    .WithMany()
                    .HasForeignKey(p => p.PhotoId),
                pp => pp
                    .HasOne(p => p.Post)
                    .WithMany()
                    .HasForeignKey(p => p.PostId),
                pp =>
                    pp.HasKey(t => new { t.PostId, t.PhotoId }));
    }
}