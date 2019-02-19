using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedPet.Database.Entities;

namespace RedPet.Database.EntityTypeConfigurations
{
    public class PromotionServiceEntityTypeConfiguration : IEntityTypeConfiguration<PromotionService>
    {
        public void Configure(EntityTypeBuilder<PromotionService> builder)
        {
            builder.HasOne(x => x.Service).WithMany();
            builder.HasOne(x => x.Promotion).WithMany(x=>x.PromotionServices);
        }
    }
}
