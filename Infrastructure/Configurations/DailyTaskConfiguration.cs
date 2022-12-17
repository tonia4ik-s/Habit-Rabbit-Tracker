using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class DailyTaskConfiguration : IEntityTypeConfiguration<DailyTask>
    {
        public void Configure(EntityTypeBuilder<DailyTask> builder)
        {
            builder
                .HasOne(p => p.Challenge)
                .WithMany(p => p.DailyTasks)
                .HasForeignKey(p => p.ChallengeId);
            builder
                .HasOne(p => p.Subtask)
                .WithMany(p => p.DailyTasks)
                .HasForeignKey(p => p.SubtaskId)
                .IsRequired(false);
            builder
                .Property(p => p.AssignedDate)
                .IsRequired();
            builder
                .Property(p => p.IsDone)
                .HasDefaultValue(false);
        }
    }

