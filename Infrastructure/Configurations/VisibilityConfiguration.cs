using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class VisibilityConfiguration : IEntityTypeConfiguration<Visibility>
    {
        public void Configure(EntityTypeBuilder<Visibility> builder)
        {
            builder
                .HasMany(p => p.Challenges)
                .WithOne(p => p.Visibility)
                .HasForeignKey(p => p.VisibilityId);
        }
    }
}