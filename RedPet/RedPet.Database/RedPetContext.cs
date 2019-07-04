using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RedPet.Database.Entities;
using RedPet.Database.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RedPet.Database.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace RedPet.Database
{
    public class RedPetContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public RedPetContext(DbContextOptions<RedPetContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<ServicePetSize> ServicePricePetSizes { get; set; }
        public DbSet<ServiceSubService> ServicePriceServiceSubTypes { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<SubService> ServiceSubTypes { get; set; }

        public DbSet<Provider> Providers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Nationality> Nationalities{ get; set; }
        public DbSet<IdentificationType> IdentificationTypes { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionProduct> PromotionsProducts { get; set; }
        public DbSet<PromotionService> PromotionsServices { get; set; }
        public DbSet<Audience> Audiences { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<WeightRange> WeightRanges { get; set; }
        public DbSet<PetSize> PetSizes { get; set; }
        public DbSet<HairType> HairTypes { get; set; }
        public DbSet<Breed> Breeds { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var typesToRegister = typeof(PetEntityTypeConfiguration).Assembly.GetTypes()
                         .Where(t => t.GetInterfaces().Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();


            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }

    public class RedPetContextFactory : IDesignTimeDbContextFactory<RedPetContext>
    {
        public RedPetContext CreateDbContext(string[] args)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //  .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //  .AddJsonFile("appsettings.json")
            //  .Build();
            //configuration.GetConnectionString("RedPet")
            var builder = new DbContextOptionsBuilder<RedPetContext>();
            builder.UseSqlServer("Data Source=SQL5041.site4now.net;Initial Catalog=DB_A45CF7_redpet;User Id=DB_A45CF7_redpet_admin;Password=redpet123;");
            return new RedPetContext(builder.Options);
        }
    }
}
