using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class IconConfiguration : IEntityTypeConfiguration<Icon>
    {
        public void Configure(EntityTypeBuilder<Icon> builder)
        {
            builder
                .HasMany(p => p.Challenges)
                .WithOne(p => p.Icon)
                .HasForeignKey(p => p.VisibilityId);
        }
    }
}