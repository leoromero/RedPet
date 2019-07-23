using Microsoft.EntityFrameworkCore;
using RedPet.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedPet.Database.Repositories
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(RedPetContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Service>> GetAsync()
        {
            return await DbSet
                .Include(x => x.ServicePetSizes).ThenInclude(x => x.PetSize)
                .Include(x => x.ServiceSubServices).ThenInclude(x => x.ServiceSubType)
                .Include(x => x.ServiceFrecuencies).ThenInclude(x => x.Frecuency)
                .Include(x => x.Provider)
                .Include(x => x.ServiceType)
                .Include(x => x.WeekDays)
                .ToListAsync();
        }
    }

    public interface IServiceRepository : IRepository<Service>
    {
    }
}
