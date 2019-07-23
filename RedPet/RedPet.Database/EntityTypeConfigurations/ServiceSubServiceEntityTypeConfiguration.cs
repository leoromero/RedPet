using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedPet.Database.Entities;

namespace RedPet.Database.EntityTypeConfigurations
{
    public class ServiceSubServiceEntityTypeConfiguration : IEntityTypeConfiguration<ServiceSubService>
    {
        public void Configure(EntityTypeBuilder<ServiceSubService> builder)
        {
            builder.ToTable("ServiceSubServices");
            builder.HasOne(x => x.ServiceSubType).WithMany();
            builder.HasOne(x => x.Service).WithMany(x => x.ServiceSubServices);
        }
    }
}
