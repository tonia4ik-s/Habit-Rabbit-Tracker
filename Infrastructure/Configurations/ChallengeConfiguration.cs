using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
{
    public void Configure(EntityTypeBuilder<Challenge> builder)
    {
        builder.HasKey(p => p.Id);
        builder
            .HasOne(p => p.CreatedBy)
            .WithMany(p => p.AuthoredChallenges)
            .HasForeignKey(p => p.CreatedById);
        builder
            .Property(p => p.Title)
            .IsRequired();
        builder
            .Property(p => p.CountOfUnits)
            .IsRequired();
        builder
            .HasOne(p => p.Unit)
            .WithMany(p => p.Challenges)
            .HasForeignKey(p => p.UnitId);
        builder
            .HasOne(p => p.Visibility)
            .WithMany(p => p.Challenges)
            .HasForeignKey(p => p.VisibilityId);
        builder
            .HasOne(p => p.ChallengeType)
            .WithMany(p => p.Challenges)
            .HasForeignKey(p => p.ChallengeTypeId);
        builder
            .Property(p => p.IsCompleted)
            .HasDefaultValue(false);
        builder
            .HasMany(p => p.DailyTasks)
            .WithOne(p => p.Challenge)
            .HasForeignKey(p => p.ChallengeId);
        builder
            .HasMany(p => p.Users)
            .WithMany(p => p.Challenges);
    }
}