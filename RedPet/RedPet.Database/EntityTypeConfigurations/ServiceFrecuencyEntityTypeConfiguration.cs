using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedPet.Database.Entities;

namespace RedPet.Database.EntityTypeConfigurations
{
    public class ServiceFrecuencyEntityTypeConfiguration : IEntityTypeConfiguration<ServiceFrecuency>
    {
        public void Configure(EntityTypeBuilder<ServiceFrecuency> builder)
        {
            builder.HasOne(x => x.Frecuency).WithMany();
            builder.HasOne(x => x.Service).WithMany(x => x.ServiceFrecuencies);
        }
    }
}
