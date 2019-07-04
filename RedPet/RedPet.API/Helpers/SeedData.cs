using Microsoft.AspNetCore.Identity;
using RedPet.Common.Models.Pet;
using RedPet.Common.Models.Provider;
using RedPet.Common.Models.Service;
using RedPet.Core;
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

            if (!petSizes.Exists(x => x.Name.ToLower().Trim() == "mini"))
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
                var breed = new WeightRangeModel { Name = "0kg - 10kg", From = 0, To = 10 };
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

        public static async Task SeedIdTypesAsync(IIdentificationTypeService idTypeService)
        {
            var types = idTypeService.GetAsync().Result.Entity;

            var basicTypes = new List<string> { "Cedula", "Pasaporte" };
            foreach (var type in basicTypes)
            {
                if (!types.Any(x => x.Name == type))
                {
                    var newType = new IdentificationTypeModel { Name = type };
                    await idTypeService.CreateAsync(newType);
                }
            }
        }

        public static async Task SeedFrecuenciesAsync(IFrecuencyService frecuencyService)
        {
            var types = frecuencyService.GetAsync().Result.Entity;

            var basicTypes = new List<string> { "Unica vez", "Semanal", "Mensual" };
            foreach (var type in basicTypes)
            {
                if (!types.Any(x => x.Name == type))
                {
                    var newType = new FrecuencyModel { Name = type };
                    await frecuencyService.CreateAsync(newType);
                }
            }
        }

        public static async Task SeedServiceTypesAsync(IServiceTypeService serviceTypeService)
        {
            var types = serviceTypeService.GetAsync().Result.Entity;

            var basicTypes = new List<string> { "Guardería", "Peluquería", "Hospedaje", "Paseos" };
            foreach (var type in basicTypes)
            {
                if (!types.Any(x => x.Name == type))
                {
                    var newType = new ServiceTypeModel { Name = type };
                    await serviceTypeService.CreateAsync(newType);
                }
            }
        }

        public static async Task SeedNationalitiessAsync(INationalityService nationalityService)
        {
            var nationalities = nationalityService.GetAsync().Result.Entity;

            var initialNationalities = new List<NationalityModel>() {
                new NationalityModel{ Code= "AFG", Nation="Afganistán" },
                new NationalityModel{ Code= "ALB", Nation="Albania" },
                new NationalityModel{ Code= "DEU", Nation="Alemania" },
                new NationalityModel{ Code= "AND", Nation="Andorra" },
                new NationalityModel{ Code= "AGO", Nation="Angola" },
                new NationalityModel{ Code= "AIA", Nation="Anguila" },
                new NationalityModel{ Code= "ATA", Nation="Antártida" },
                new NationalityModel{ Code= "ATG", Nation="Antigua y Barbuda" },
                new NationalityModel{ Code= "SAU", Nation="Arabia Saudita" },
                new NationalityModel{ Code= "DZA", Nation="Argelia" },
                new NationalityModel{ Code= "ARG", Nation="Argentina" },
                new NationalityModel{ Code= "ARM", Nation="Armenia" },
                new NationalityModel{ Code= "ABW", Nation="Aruba" },
                new NationalityModel{ Code= "AUS", Nation="Australia" },
                new NationalityModel{ Code= "AUT", Nation="Austria" },
                new NationalityModel{ Code= "AZE", Nation="Azerbaiyán" },
                new NationalityModel{ Code= "BHS", Nation="Bahamas" },
                new NationalityModel{ Code= "BGD", Nation="Bangladés" },
                new NationalityModel{ Code= "BRB", Nation="Barbados" },
                new NationalityModel{ Code= "BHR", Nation="Baréin" },
                new NationalityModel{ Code= "BEL", Nation="Bélgica" },
                new NationalityModel{ Code= "BLZ", Nation="Belice" },
                new NationalityModel{ Code= "BEN", Nation="Benín" },
                new NationalityModel{ Code= "BMU", Nation="Bermudas" },
                new NationalityModel{ Code= "BLR", Nation="Bielorrusia" },
                new NationalityModel{ Code= "MMR", Nation="Myanmar" },
                new NationalityModel{ Code= "BOL", Nation="Bolivia" },
                new NationalityModel{ Code= "BIH", Nation="Bosnia y Herzegovina" },
                new NationalityModel{ Code= "BWA", Nation="Botsuana" },
                new NationalityModel{ Code= "BRA", Nation="Brasil" },
                new NationalityModel{ Code= "BRN", Nation="Brunéi Darussalam" },
                new NationalityModel{ Code= "BGR", Nation="Bulgaria" },
                new NationalityModel{ Code= "BFA", Nation="Burkina Faso" },
                new NationalityModel{ Code= "BDI", Nation="Burundi" },
                new NationalityModel{ Code= "BTN", Nation="Bután" },
                new NationalityModel{ Code= "CPV", Nation="Cabo Verde" },
                new NationalityModel{ Code= "KHM", Nation="Camboya" },
                new NationalityModel{ Code= "CMR", Nation="Camerún" },
                new NationalityModel{ Code= "CAN", Nation="Canadá" },
                new NationalityModel{ Code= "QAT", Nation="Catar" },
                new NationalityModel{ Code= "BES", Nation="Bonaire" },
                new NationalityModel{ Code= "TCD", Nation="Chad" },
                new NationalityModel{ Code= "CHL", Nation="Chile" },
                new NationalityModel{ Code= "CHN", Nation="China" },
                new NationalityModel{ Code= "CYP", Nation="Chipre" },
                new NationalityModel{ Code= "COL", Nation="Colombia" },
                new NationalityModel{ Code= "COM", Nation="Comoras" },
                new NationalityModel{ Code= "KOR", Nation="Corea" },
                new NationalityModel{ Code= "CIV", Nation="Costa de Marfil" },
                new NationalityModel{ Code= "CRI", Nation="Costa Rica" },
                new NationalityModel{ Code= "HRV", Nation="Croacia" },
                new NationalityModel{ Code= "CUB", Nation="Cuba" },
                new NationalityModel{ Code= "CUW", Nation="Curaçao" },
                new NationalityModel{ Code= "DNK", Nation="Dinamarca" },
                new NationalityModel{ Code= "DMA", Nation="Dominica" },
                new NationalityModel{ Code= "ECU", Nation="Ecuador" },
                new NationalityModel{ Code= "EGY", Nation="Egipto" },
                new NationalityModel{ Code= "SLV", Nation="El Salvador" },
                new NationalityModel{ Code= "ARE", Nation="Emiratos Árabes Unidos" },
                new NationalityModel{ Code= "ERI", Nation="Eritrea" },
                new NationalityModel{ Code= "SVK", Nation="Eslovaquia" },
                new NationalityModel{ Code= "SVN", Nation="Eslovenia" },
                new NationalityModel{ Code= "ESP", Nation="España" },
                new NationalityModel{ Code= "USA", Nation="Estados Unidos" },
                new NationalityModel{ Code= "EST", Nation="Estonia" },
                new NationalityModel{ Code= "ETH", Nation="Etiopía" },
                new NationalityModel{ Code= "PHL", Nation="Filipinas" },
                new NationalityModel{ Code= "FIN", Nation="Finlandia" },
                new NationalityModel{ Code= "FJI", Nation="Fiyi" },
                new NationalityModel{ Code= "FRA", Nation="Francia" },
                new NationalityModel{ Code= "GAB", Nation="Gabón" },
                new NationalityModel{ Code= "GMB", Nation="Gambia" },
                new NationalityModel{ Code= "GEO", Nation="Georgia" },
                new NationalityModel{ Code= "GHA", Nation="Ghana" },
                new NationalityModel{ Code= "GIB", Nation="Gibraltar" },
                new NationalityModel{ Code= "GRD", Nation="Granada" },
                new NationalityModel{ Code= "GRC", Nation="Grecia" },
                new NationalityModel{ Code= "GRL", Nation="Groenlandia" },
                new NationalityModel{ Code= "GLP", Nation="Guadalupe" },
                new NationalityModel{ Code= "GUM", Nation="Guam" },
                new NationalityModel{ Code= "GTM", Nation="Guatemala" },
                new NationalityModel{ Code= "GUF", Nation="Guayana Francesa" },
                new NationalityModel{ Code= "GGY", Nation="Guernsey" },
                new NationalityModel{ Code= "GIN", Nation="Guinea" },
                new NationalityModel{ Code= "GNB", Nation="Guinea-Bisáu" },
                new NationalityModel{ Code= "GNQ", Nation="Guinea Ecuatorial" },
                new NationalityModel{ Code= "GUY", Nation="Guyana" },
                new NationalityModel{ Code= "HTI", Nation="Haití" },
                new NationalityModel{ Code= "HND", Nation="Honduras" },
                new NationalityModel{ Code= "HKG", Nation="Hong Kong" },
                new NationalityModel{ Code= "HUN", Nation="Hungría" },
                new NationalityModel{ Code= "IND", Nation="India" },
                new NationalityModel{ Code= "IDN", Nation="Indonesia" },
                new NationalityModel{ Code= "IRQ", Nation="Irak" },
                new NationalityModel{ Code= "IRN", Nation="Irán" },
                new NationalityModel{ Code= "IRL", Nation="Irlanda" },
                new NationalityModel{ Code= "BVT", Nation="Isla Bouvet" },
                new NationalityModel{ Code= "IMN", Nation="Isla de Man" },
                new NationalityModel{ Code= "CXR", Nation="Isla de Navidad" },
                new NationalityModel{ Code= "NFK", Nation="Isla Norfolk" },
                new NationalityModel{ Code= "ISL", Nation="Islandia" },
                new NationalityModel{ Code= "CYM", Nation="Islas Caimán" },
                new NationalityModel{ Code= "CCK", Nation="Islas Cocos" },
                new NationalityModel{ Code= "COK", Nation="Islas Cook" },
                new NationalityModel{ Code= "FRO", Nation="Islas Feroe" },
                new NationalityModel{ Code= "SGS", Nation="Georgia del sur y las islas sandwich del sur" },
                new NationalityModel{ Code= "HMD", Nation="Isla Heard e Islas McDonald" },
                new NationalityModel{ Code= "FLK", Nation="Islas Malvinas" },
                new NationalityModel{ Code= "MNP", Nation="Islas Marianas del Norte" },
                new NationalityModel{ Code= "MHL", Nation="Islas Marshall" },
                new NationalityModel{ Code= "PCN", Nation="Pitcairn" },
                new NationalityModel{ Code= "SLB", Nation="Islas Salomón" },
                new NationalityModel{ Code= "TCA", Nation="Islas Turcas y Caicos" },
                new NationalityModel{ Code= "UMI", Nation="Islas de Ultramar Menores de Estados Unidos" },
                new NationalityModel{ Code= "VIR", Nation="Islas Vírgenes" },
                new NationalityModel{ Code= "ISR", Nation="Israel" },
                new NationalityModel{ Code= "ITA", Nation="Italia" },
                new NationalityModel{ Code= "JAM", Nation="Jamaica" },
                new NationalityModel{ Code= "JPN", Nation="Japón" },
                new NationalityModel{ Code= "JEY", Nation="Jersey" },
                new NationalityModel{ Code= "JOR", Nation="Jordania" },
                new NationalityModel{ Code= "KAZ", Nation="Kazajistán" },
                new NationalityModel{ Code= "KEN", Nation="Kenia" },
                new NationalityModel{ Code= "KGZ", Nation="Kirguistán" },
                new NationalityModel{ Code= "KIR", Nation="Kiribati" },
                new NationalityModel{ Code= "KWT", Nation="Kuwait" },
                new NationalityModel{ Code= "LAO", Nation="Lao" },
                new NationalityModel{ Code= "LSO", Nation="Lesoto" },
                new NationalityModel{ Code= "LVA", Nation="Letonia" },
                new NationalityModel{ Code= "LBN", Nation="Líbano" },
                new NationalityModel{ Code= "LBR", Nation="Liberia" },
                new NationalityModel{ Code= "LBY", Nation="Libia" },
                new NationalityModel{ Code= "LIE", Nation="Liechtenstein" },
                new NationalityModel{ Code= "LTU", Nation="Lituania" },
                new NationalityModel{ Code= "LUX", Nation="Luxemburgo" },
                new NationalityModel{ Code= "MAC", Nation="Macao" },
                new NationalityModel{ Code= "MDG", Nation="Madagascar" },
                new NationalityModel{ Code= "MYS", Nation="Malasia" },
                new NationalityModel{ Code= "MWI", Nation="Malaui" },
                new NationalityModel{ Code= "MDV", Nation="Maldivas" },
                new NationalityModel{ Code= "MLI", Nation="Malí" },
                new NationalityModel{ Code= "MLT", Nation="Malta" },
                new NationalityModel{ Code= "MAR", Nation="Marruecos" },
                new NationalityModel{ Code= "MTQ", Nation="Martinica" },
                new NationalityModel{ Code= "MUS", Nation="Mauricio" },
                new NationalityModel{ Code= "MRT", Nation="Mauritania" },
                new NationalityModel{ Code= "MYT", Nation="Mayotte" },
                new NationalityModel{ Code= "MEX", Nation="México" },
                new NationalityModel{ Code= "FSM", Nation="Micronesia" },
                new NationalityModel{ Code= "MDA", Nation="Moldavia" },
                new NationalityModel{ Code= "MCO", Nation="Mónaco" },
                new NationalityModel{ Code= "MNG", Nation="Mongolia" },
                new NationalityModel{ Code= "MNE", Nation="Montenegro" },
                new NationalityModel{ Code= "MSR", Nation="Montserrat" },
                new NationalityModel{ Code= "MOZ", Nation="Mozambique" },
                new NationalityModel{ Code= "NAM", Nation="Namibia" },
                new NationalityModel{ Code= "NRU", Nation="Nauru" },
                new NationalityModel{ Code= "NPL", Nation="Nepal" },
                new NationalityModel{ Code= "NIC", Nation="Nicaragua" },
                new NationalityModel{ Code= "NER", Nation="Níger" },
                new NationalityModel{ Code= "NGA", Nation="Nigeria" },
                new NationalityModel{ Code= "NIU", Nation="Niue" },
                new NationalityModel{ Code= "NOR", Nation="Noruega" },
                new NationalityModel{ Code= "NCL", Nation="Nueva Caledonia" },
                new NationalityModel{ Code= "NZL", Nation="Nueva Zelanda" },
                new NationalityModel{ Code= "OMN", Nation="Omán" },
                new NationalityModel{ Code= "NLD", Nation="Países Bajos" },
                new NationalityModel{ Code= "PAK", Nation="Pakistán" },
                new NationalityModel{ Code= "PLW", Nation="Palaos" },
                new NationalityModel{ Code= "PSE", Nation="Palestina, Estado de" },
                new NationalityModel{ Code= "PAN", Nation="Panamá" },
                new NationalityModel{ Code= "PNG", Nation="Papúa Nueva Guinea" },
                new NationalityModel{ Code= "PRY", Nation="Paraguay" },
                new NationalityModel{ Code= "PER", Nation="Perú" },
                new NationalityModel{ Code= "PYF", Nation="Polinesia Francesa" },
                new NationalityModel{ Code= "POL", Nation="Polonia" },
                new NationalityModel{ Code= "PRT", Nation="Portugal" },
                new NationalityModel{ Code= "PRI", Nation="Puerto Rico" },
                new NationalityModel{ Code= "GBR", Nation="Reino Unido" },
                new NationalityModel{ Code= "CAF", Nation="República Centroafricana" },
                new NationalityModel{ Code= "CZE", Nation="República Checa" },
                new NationalityModel{ Code= "MKD", Nation="Macedonia" },
                new NationalityModel{ Code= "COG", Nation="Congo" },
                new NationalityModel{ Code= "DOM", Nation="República Dominicana" },
                new NationalityModel{ Code= "REU", Nation="Reunión" },
                new NationalityModel{ Code= "RWA", Nation="Ruanda" },
                new NationalityModel{ Code= "ROU", Nation="Rumania" },
                new NationalityModel{ Code= "RUS", Nation="Rusia" },
                new NationalityModel{ Code= "ESH", Nation="Sahara Occidental" },
                new NationalityModel{ Code= "WSM", Nation="Samoa" },
                new NationalityModel{ Code= "ASM", Nation="Samoa Americana" },
                new NationalityModel{ Code= "BLM", Nation="San Bartolomé" },
                new NationalityModel{ Code= "KNA", Nation="San Cristóbal y Nieves" },
                new NationalityModel{ Code= "SMR", Nation="San Marino" },
                new NationalityModel{ Code= "MAF", Nation="San Martín" },
                new NationalityModel{ Code= "SPM", Nation="San Pedro y Miquelón" },
                new NationalityModel{ Code= "VCT", Nation="San Vicente y las Granadinas" },
                new NationalityModel{ Code= "SHN", Nation="Santa Helena" },
                new NationalityModel{ Code= "LCA", Nation="Santa Lucía" },
                new NationalityModel{ Code= "STP", Nation="Santo Tomé y Príncipe" },
                new NationalityModel{ Code= "SEN", Nation="Senegal" },
                new NationalityModel{ Code= "SRB", Nation="Serbia" },
                new NationalityModel{ Code= "SYC", Nation="Seychelles" },
                new NationalityModel{ Code= "SLE", Nation="Sierra leona" },
                new NationalityModel{ Code= "SGP", Nation="Singapur" },
                new NationalityModel{ Code= "SXM", Nation="Sint Maarten" },
                new NationalityModel{ Code= "SYR", Nation="Siria" },
                new NationalityModel{ Code= "SOM", Nation="Somalia" },
                new NationalityModel{ Code= "LKA", Nation="Sri Lanka" },
                new NationalityModel{ Code= "SWZ", Nation="Suazilandia" },
                new NationalityModel{ Code= "ZAF", Nation="Sudáfrica" },
                new NationalityModel{ Code= "SDN", Nation="Sudán" },
                new NationalityModel{ Code= "SSD", Nation="Sudán del Sur" },
                new NationalityModel{ Code= "SWE", Nation="Suecia" },
                new NationalityModel{ Code= "CHE", Nation="Suiza" },
                new NationalityModel{ Code= "SUR", Nation="Surinam" },
                new NationalityModel{ Code= "SJM", Nation="Svalbard y Jan Mayen" },
                new NationalityModel{ Code= "THA", Nation="Tailandia" },
                new NationalityModel{ Code= "TWN", Nation="Taiwán" },
                new NationalityModel{ Code= "TZA", Nation="Tanzania" },
                new NationalityModel{ Code= "TJK", Nation="Tayikistán" },
                new NationalityModel{ Code= "IOT", Nation="Territorio Británico del Océano Índico" },
                new NationalityModel{ Code= "ATF", Nation="Territorios Australes Franceses" },
                new NationalityModel{ Code= "TLS", Nation="Timor-Leste" },
                new NationalityModel{ Code= "TGO", Nation="Togo" },
                new NationalityModel{ Code= "TKL", Nation="Tokelau" },
                new NationalityModel{ Code= "TON", Nation="Tonga" },
                new NationalityModel{ Code= "TTO", Nation="Trinidad y Tobago" },
                new NationalityModel{ Code= "TUN", Nation="Túnez" },
                new NationalityModel{ Code= "TKM", Nation="Turkmenistán" },
                new NationalityModel{ Code= "TUR", Nation="Turquía" },
                new NationalityModel{ Code= "TUV", Nation="Tuvalu" },
                new NationalityModel{ Code= "UKR", Nation="Ucrania" },
                new NationalityModel{ Code= "UGA", Nation="Uganda" },
                new NationalityModel{ Code= "URY", Nation="Uruguay" },
                new NationalityModel{ Code= "UZB", Nation="Uzbekistán" },
                new NationalityModel{ Code= "VUT", Nation="Vanuatu" },
                new NationalityModel{ Code= "VEN", Nation="Venezuela" },
                new NationalityModel{ Code= "VNM", Nation="Vietnam" },
                new NationalityModel{ Code= "WLF", Nation="Wallis y Futuna" },
                new NationalityModel{ Code= "YEM", Nation="Yemen" },
                new NationalityModel{ Code= "DJI", Nation="Yibuti" },
                new NationalityModel{ Code= "ZMB", Nation="Zambia" },
                new NationalityModel{ Code= "ZWE", Nation="Zimbabue" }
            };
            foreach (var nationality in initialNationalities)
            {
                if (!nationalities.Any(x => x.Nation == nationality.Nation))
                {
                    await nationalityService.CreateAsync(nationality);
                }
            }
        }
    }
}
