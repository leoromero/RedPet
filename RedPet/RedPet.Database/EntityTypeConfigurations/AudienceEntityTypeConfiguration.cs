using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedPet.Database.Entities;

namespace RedPet.Database.EntityTypeConfigurations
{
    public class AudienceEntityTypeConfiguration : IEntityTypeConfiguration<Audience>
    {
        public void Configure(EntityTypeBuilder<Audience> builder)
        {
            builder.HasOne(x => x.Breed).WithMany();
            builder.HasOne(x => x.PetSize).WithMany();
            builder.HasOne(x => x.WeightRange).WithMany();
        }
    }
}
