using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedPet.Database.Entities;

namespace RedPet.Database.EntityTypeConfigurations
{
    public class HairEntityTypeConfiguration : IEntityTypeConfiguration<HairType>
    {
        public void Configure(EntityTypeBuilder<HairType> builder)
        {           
        }
    }
}
