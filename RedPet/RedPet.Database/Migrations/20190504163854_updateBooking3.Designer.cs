﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedPet.Database;

namespace RedPet.Database.Migrations
{
    [DbContext(typeof(RedPetContext))]
    [Migration("20190504163854_updateBooking3")]
    partial class updateBooking3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RedPet.Database.Entities.Audience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BreedId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<string>("Name");

                    b.Property<int?>("PetSizeId");

                    b.Property<int?>("WeightRangeId");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.HasIndex("PetSizeId");

                    b.HasIndex("WeightRangeId");

                    b.ToTable("Audiences");
                });

            modelBuilder.Entity("RedPet.Database.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("DeliveryDateTime");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<int?>("PetId");

                    b.Property<decimal>("Price");

                    b.Property<int?>("ProductId");

                    b.Property<int?>("PromotionId");

                    b.Property<int?>("ServiceId");

                    b.Property<int>("StateId");

                    b.Property<decimal>("Taxes");

                    b.Property<decimal>("TotalPrice");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PetId");

                    b.HasIndex("ProductId");

                    b.HasIndex("PromotionId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("StateId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("RedPet.Database.Entities.Breed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("HairTypeId");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<string>("Name");

                    b.Property<int?>("PetSizeId");

                    b.HasKey("Id");

                    b.HasIndex("HairTypeId");

                    b.HasIndex("PetSizeId");

                    b.ToTable("Breeds");
                });

            modelBuilder.Entity("RedPet.Database.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("RedPet.Database.Entities.HairType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("HairTypes");
                });

            modelBuilder.Entity("RedPet.Database.Entities.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<long>("FacebookId");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("RefreshToken");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("RedPet.Database.Entities.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<int?>("BreedId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<int>("MealsPerDay");

                    b.Property<string>("Name");

                    b.Property<string>("Observations");

                    b.Property<int>("OwnerId");

                    b.Property<int?>("PetSizeId");

                    b.Property<string>("PreferedFood");

                    b.Property<bool>("Sterilized");

                    b.Property<bool>("VaccinesUpToDate");

                    b.Property<int?>("VetId");

                    b.Property<int?>("WeightRangeId");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PetSizeId");

                    b.HasIndex("VetId");

                    b.HasIndex("WeightRangeId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("RedPet.Database.Entities.PetSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<string>("Name");

                    b.Property<int?>("WeightRangeId");

                    b.HasKey("Id");

                    b.HasIndex("WeightRangeId");

                    b.ToTable("PetSizes");
                });

            modelBuilder.Entity("RedPet.Database.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("Taxes");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("RedPet.Database.Entities.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AudienceId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<decimal>("Discount");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("Taxes");

                    b.HasKey("Id");

                    b.HasIndex("AudienceId");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("RedPet.Database.Entities.PromotionProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<int>("ProductId");

                    b.Property<int>("PromotionId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("PromotionId");

                    b.ToTable("PromotionsProducts");
                });

            modelBuilder.Entity("RedPet.Database.Entities.PromotionService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<int>("PromotionId");

                    b.Property<int>("ServiceId");

                    b.HasKey("Id");

                    b.HasIndex("PromotionId");

                    b.HasIndex("ServiceId");

                    b.ToTable("PromotionsServices");
                });

            modelBuilder.Entity("RedPet.Database.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<string>("Name");

                    b.Property<int?>("PetSizeId");

                    b.Property<decimal>("Price");

                    b.Property<int>("ServiceTypeId");

                    b.Property<decimal>("Taxes");

                    b.HasKey("Id");

                    b.HasIndex("PetSizeId");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("RedPet.Database.Entities.ServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ServiceType");
                });

            modelBuilder.Entity("RedPet.Database.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("State");
                });

            modelBuilder.Entity("RedPet.Database.Entities.Vaccination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<int>("PetId");

                    b.Property<int>("VaccineId");

                    b.Property<DateTime>("VacinationDate");

                    b.HasKey("Id");

                    b.HasAlternateKey("PetId", "VaccineId");

                    b.HasIndex("VaccineId");

                    b.ToTable("Vaccination");
                });

            modelBuilder.Entity("RedPet.Database.Entities.Vaccine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<string>("Info");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Vaccine");
                });

            modelBuilder.Entity("RedPet.Database.Entities.Vet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Vet");
                });

            modelBuilder.Entity("RedPet.Database.Entities.WeightRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("From");

                    b.Property<DateTime?>("InactivationDate");

                    b.Property<string>("Name");

                    b.Property<int?>("To");

                    b.HasKey("Id");

                    b.ToTable("WeightRanges");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.HasOne("RedPet.Database.Entities.Identity.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("RedPet.Database.Entities.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("RedPet.Database.Entities.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RedPet.Database.Entities.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("RedPet.Database.Entities.Identity.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RedPet.Database.Entities.Audience", b =>
                {
                    b.HasOne("RedPet.Database.Entities.Breed", "Breed")
                        .WithMany()
                        .HasForeignKey("BreedId");

                    b.HasOne("RedPet.Database.Entities.PetSize", "PetSize")
                        .WithMany()
                        .HasForeignKey("PetSizeId");

                    b.HasOne("RedPet.Database.Entities.WeightRange", "WeightRange")
                        .WithMany()
                        .HasForeignKey("WeightRangeId");
                });

            modelBuilder.Entity("RedPet.Database.Entities.Booking", b =>
                {
                    b.HasOne("RedPet.Database.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RedPet.Database.Entities.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RedPet.Database.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("RedPet.Database.Entities.Promotion", "Promotion")
                        .WithMany()
                        .HasForeignKey("PromotionId");

                    b.HasOne("RedPet.Database.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId");

                    b.HasOne("RedPet.Database.Entities.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RedPet.Database.Entities.Breed", b =>
                {
                    b.HasOne("RedPet.Database.Entities.HairType", "HairType")
                        .WithMany()
                        .HasForeignKey("HairTypeId");

                    b.HasOne("RedPet.Database.Entities.PetSize", "PetSize")
                        .WithMany()
                        .HasForeignKey("PetSizeId");
                });

            modelBuilder.Entity("RedPet.Database.Entities.Customer", b =>
                {
                    b.HasOne("RedPet.Database.Entities.Identity.User", "User")
                        .WithOne()
                        .HasForeignKey("RedPet.Database.Entities.Customer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RedPet.Database.Entities.Pet", b =>
                {
                    b.HasOne("RedPet.Database.Entities.Breed", "Breed")
                        .WithMany()
                        .HasForeignKey("BreedId");

                    b.HasOne("RedPet.Database.Entities.Customer", "Owner")
                        .WithMany("Pets")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RedPet.Database.Entities.PetSize", "PetSize")
                        .WithMany()
                        .HasForeignKey("PetSizeId");

                    b.HasOne("RedPet.Database.Entities.Vet", "Vet")
                        .WithMany()
                        .HasForeignKey("VetId");

                    b.HasOne("RedPet.Database.Entities.WeightRange", "WeightRange")
                        .WithMany()
                        .HasForeignKey("WeightRangeId");
                });

            modelBuilder.Entity("RedPet.Database.Entities.PetSize", b =>
                {
                    b.HasOne("RedPet.Database.Entities.WeightRange", "WeightRange")
                        .WithMany()
                        .HasForeignKey("WeightRangeId");
                });

            modelBuilder.Entity("RedPet.Database.Entities.Promotion", b =>
                {
                    b.HasOne("RedPet.Database.Entities.Audience", "Audience")
                        .WithMany()
                        .HasForeignKey("AudienceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RedPet.Database.Entities.PromotionProduct", b =>
                {
                    b.HasOne("RedPet.Database.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RedPet.Database.Entities.Promotion", "Promotion")
                        .WithMany("PromotionProducts")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RedPet.Database.Entities.PromotionService", b =>
                {
                    b.HasOne("RedPet.Database.Entities.Promotion", "Promotion")
                        .WithMany("PromotionServices")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RedPet.Database.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RedPet.Database.Entities.Service", b =>
                {
                    b.HasOne("RedPet.Database.Entities.PetSize", "PetSize")
                        .WithMany()
                        .HasForeignKey("PetSizeId");

                    b.HasOne("RedPet.Database.Entities.ServiceType", "Type")
                        .WithMany()
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RedPet.Database.Entities.Vaccination", b =>
                {
                    b.HasOne("RedPet.Database.Entities.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RedPet.Database.Entities.Vaccine", "Vaccine")
                        .WithMany()
                        .HasForeignKey("VaccineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
