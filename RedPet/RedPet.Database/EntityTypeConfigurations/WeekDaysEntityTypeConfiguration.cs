using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedPet.Database.Entities;

namespace RedPet.Database.EntityTypeConfigurations
{
    public class WeekDaysEntityTypeConfiguration : IEntityTypeConfiguration<WeekDays>
    {
        public void Configure(EntityTypeBuilder<WeekDays> builder)
        {
        }
    }
}
