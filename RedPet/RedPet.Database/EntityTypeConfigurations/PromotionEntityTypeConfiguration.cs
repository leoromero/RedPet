using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedPet.Database.Entities;

namespace RedPet.Database.EntityTypeConfigurations
{
    public class PromotionEntityTypeConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.HasMany(x => x.PromotionProducts).WithOne();
            builder.HasMany(x => x.PromotionServices).WithOne();
            builder.HasOne(x => x.Audience).WithMany();
        }
    }
}
