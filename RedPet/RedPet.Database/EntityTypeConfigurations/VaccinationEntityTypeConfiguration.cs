using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedPet.Database.Entities;

namespace RedPet.Database.EntityTypeConfigurations
{
    public class VaccinationEntityTypeConfiguration : IEntityTypeConfiguration<Vaccination>
    {
        public void Configure(EntityTypeBuilder<Vaccination> builder)
        {
            builder.HasOne(x => x.Vaccine).WithMany();
            builder.HasAlternateKey(x => new { x.PetId, x.VaccineId });
        }
    }
}
