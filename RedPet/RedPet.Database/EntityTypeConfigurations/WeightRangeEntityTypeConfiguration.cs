using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedPet.Database.Entities;

namespace RedPet.Database.EntityTypeConfigurations
{
    public class WeightRangeEntityTypeConfiguration : IEntityTypeConfiguration<WeightRange>
    {
        public void Configure(EntityTypeBuilder<WeightRange> builder)
        {
        }
    }
}
