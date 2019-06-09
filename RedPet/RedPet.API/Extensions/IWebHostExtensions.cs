using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RedPet.API.Helpers;
using RedPet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedPet.API.Extensions
{
    public static class IWebHostExtensions
    {
        public static IWebHost Seed(this IWebHost webhost)
        {
            using (var scope = webhost.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
                SeedData.SeedRolesAsync(roleManager).GetAwaiter().GetResult();

                var petSizeService = scope.ServiceProvider.GetRequiredService<IPetSizeService>();
                SeedData.SeedPetSizesAsync(petSizeService).GetAwaiter().GetResult();

                var breedsService = scope.ServiceProvider.GetRequiredService<IBreedService>();
                SeedData.SeedBreedsAsync(breedsService).GetAwaiter().GetResult();

                var weightRangeService = scope.ServiceProvider.GetRequiredService<IWeightRangeService>();
                SeedData.SeedWeightRangesAsync(weightRangeService).GetAwaiter().GetResult();
            }

            return webhost;
        }
    }
}
