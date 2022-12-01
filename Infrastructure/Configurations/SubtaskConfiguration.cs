using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class SubtaskConfiguration : IEntityTypeConfiguration<Subtask>
    {
        public void Configure(EntityTypeBuilder<Subtask> builder)
        {
            builder
                .HasOne(p => p.Unit)
                .WithMany(p => p.Subtasks)
                .HasForeignKey(p => p.UnitId);
            builder
                .HasOne(p => p.Challenge)
                .WithMany(p => p.Subtasks)
                .HasForeignKey(p => p.ChallengeId);
        }
    }
}