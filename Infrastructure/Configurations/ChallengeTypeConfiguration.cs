using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ChallengeTypeConfiguration : IEntityTypeConfiguration<ChallengeType>
    {
        public void Configure(EntityTypeBuilder<ChallengeType> builder)
        {
            builder
                .HasMany(p => p.Challenges)
                .WithOne(p => p.ChallengeType)
                .HasForeignKey(p => p.ChallengeTypeId);
        }
    }
}