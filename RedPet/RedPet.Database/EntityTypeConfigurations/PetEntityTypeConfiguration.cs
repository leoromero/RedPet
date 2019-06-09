using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedPet.Database.Entities;

namespace RedPet.Database.EntityTypeConfigurations
{
    public class PetEntityTypeConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasOne(x => x.Owner).WithMany(x=>x.Pets).HasForeignKey(x=>x.OwnerId);
            builder.HasOne(x => x.PetSize).WithMany();
            builder.HasOne(x => x.WeightRange).WithMany();
        }
    }
}
