using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedPet.Database.Entities;

namespace RedPet.Database.EntityTypeConfigurations
{
    public class ProviderEntityTypeConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasAlternateKey(x => x.UserId);
            builder.HasMany(x => x.Services).WithOne(x=>x.Provider);
            builder.HasOne(x => x.User).WithOne();
            builder.HasOne(x => x.IdentificationType).WithMany().IsRequired(false);
            builder.HasOne(x => x.Nationality).WithMany().IsRequired(false);
        }
    }
}
