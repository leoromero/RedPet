using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedPet.Database.Entities;

namespace RedPet.Database.EntityTypeConfigurations
{
    public class PetSizeEntityTypeConfiguration : IEntityTypeConfiguration<PetSize>
    {
        public void Configure(EntityTypeBuilder<PetSize> builder)
        {
        }
    }
}
