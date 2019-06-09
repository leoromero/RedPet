using Microsoft.AspNetCore.Identity;
using RedPet.Common.Models.Pet;
using RedPet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedPet.API.Helpers
{
    public static class SeedData
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole<int>> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var role = new IdentityRole<int> { Name = "Admin" };
                await roleManager.CreateAsync(role);
            }

            if (!await roleManager.RoleExistsAsync("Provider"))
            {
                var role = new IdentityRole<int> { Name = "Provider" };
                await roleManager.CreateAsync(role);
            }

            if (!await roleManager.RoleExistsAsync("Customer"))
            {
                var role = new IdentityRole<int> { Name = "Customer" };
                await roleManager.CreateAsync(role);
            }
        }

        public static async Task SeedPetSizesAsync(IPetSizeService petService)
        {
            var petSizes = petService.GetAsync().Result.Entity;

            if (!petSizes.Exists(x=>x.Name.ToLower().Trim() == "mini" ))
            {
                var size = new PetSizeModel { Name = "Mini" };
                await petService.CreateAsync(size);
            }
            if (!petSizes.Exists(x => x.Name.ToLower().Trim() == "pequeño"))
            {
                var size = new PetSizeModel { Name = "Pequeño" };
                await petService.CreateAsync(size);
            }
            if (!petSizes.Exists(x => x.Name.ToLower().Trim() == "mediano"))
            {
                var size = new PetSizeModel { Name = "Mediano" };
                await petService.CreateAsync(size);
            }
            if (!petSizes.Exists(x => x.Name.ToLower().Trim() == "grande"))
            {
                var size = new PetSizeModel { Name = "Grande" };
                await petService.CreateAsync(size);
            }
            if (!petSizes.Exists(x => x.Name.ToLower().Trim() == "extra grande"))
            {
                var size = new PetSizeModel { Name = "Extra Grande" };
                await petService.CreateAsync(size);
            }
        }

        public static async Task SeedBreedsAsync(IBreedService breedService)
        {
            var breeds = breedService.GetAsync().Result.Entity;

            if (!breeds.Any(x => x.Name.ToLower().Trim() == "schnauzer"))
            {
                var breed = new BreedModel { Name = "Schnauzer" };
                await breedService.CreateAsync(breed);
            }
        }
        public static async Task SeedWeightRangesAsync(IWeightRangeService weightRangeService)
        {
            var weightRanges = weightRangeService.GetAsync().Result.Entity;
            
            if (!weightRanges.Exists(x => x.Name.ToLower().Trim() == "0kg - 10kg"))
            {
                var breed = new WeightRangeModel{ Name = "0kg - 10kg", From = 0, To = 10 };
                await weightRangeService.CreateAsync(breed);
            }
            if (!weightRanges.Exists(x => x.Name.ToLower().Trim() == "10kg - 25kg"))
            {
                var breed = new WeightRangeModel { Name = "10kg - 25kg", From = 10, To = 25 };
                await weightRangeService.CreateAsync(breed);
            }
            if (!weightRanges.Exists(x => x.Name.ToLower().Trim() == "25kg - 45kg"))
            {
                var breed = new WeightRangeModel { Name = "25kg - 45kg", From = 25, To = 45 };
                await weightRangeService.CreateAsync(breed);
            }
            if (!weightRanges.Exists(x => x.Name.ToLower().Trim() == "+45kg"))
            {
                var breed = new WeightRangeModel { Name = "+45kg", From = 45 };
                await weightRangeService.CreateAsync(breed);
            }
        }        
    }
}
