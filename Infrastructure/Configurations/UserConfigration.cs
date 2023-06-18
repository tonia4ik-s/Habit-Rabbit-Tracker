using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(p => p.Points)
            .HasDefaultValue(0);
        builder.Property(p => p.Status)
            .HasDefaultValue(0);
        builder
            .HasMany(p => p.AuthoredChallenges)
            .WithOne(p => p.CreatedBy)
            .HasForeignKey(p => p.CreatedById);
        builder
            .HasMany(p => p.RefreshTokens)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
    }
}
