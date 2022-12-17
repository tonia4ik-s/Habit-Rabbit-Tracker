using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class DailySubtaskConfiguration : IEntityTypeConfiguration<DailySubtask>
{
    public void Configure(EntityTypeBuilder<DailySubtask> builder)
    {
        builder
            .HasOne(p => p.Challenge)
            .WithMany(p => p.DailySubtasks)
            .HasForeignKey(p => p.ChallengeId);
        builder
            .HasOne(p => p.Subtask)
            .WithMany(p => p.DailySubtasks)
            .HasForeignKey(p => p.SubtaskId)
            .OnDelete(deleteBehavior: DeleteBehavior.NoAction);
        builder
            .Property(p => p.AssignedDate)
            .IsRequired();
        builder
            .Property(p => p.IsDone)
            .HasDefaultValue(false);
    }
}