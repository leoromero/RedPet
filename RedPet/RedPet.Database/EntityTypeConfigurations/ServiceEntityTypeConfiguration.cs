using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedPet.Database.Entities;

namespace RedPet.Database.EntityTypeConfigurations
{
    public class ServiceEntityTypeConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasOne(x => x.ServiceType).WithMany();
            builder.HasOne(x => x.Provider).WithMany(x => x.Services);
            builder.HasMany(x => x.ServicePetSizes).WithOne(x => x.Service).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.ServiceSubServices).WithOne(x => x.Service).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.ServiceFrecuencies).WithOne(x => x.Service).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
