using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedPet.Database.Entities;

namespace RedPet.Database.EntityTypeConfigurations
{
    public class ServicePetSizeEntityTypeConfiguration : IEntityTypeConfiguration<ServicePetSize>
    {
        public void Configure(EntityTypeBuilder<ServicePetSize> builder)
        {
            builder.HasOne(x => x.PetSize).WithMany();
            builder.HasOne(x => x.Service).WithMany(x=>x.ServicePetSizes);
        }
    }
}
