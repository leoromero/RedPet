using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedPet.Database.Entities;

namespace RedPet.Database.EntityTypeConfigurations
{
    public class BookingEntityTypeConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasOne(x => x.Product).WithMany();
            builder.HasOne(x => x.Promotion).WithMany();
            builder.HasOne(x => x.Service).WithMany();
            builder.HasOne(x => x.Customer).WithMany();
        }
    }
}
