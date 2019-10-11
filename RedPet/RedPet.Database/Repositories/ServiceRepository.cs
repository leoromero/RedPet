using Microsoft.EntityFrameworkCore;
using RedPet.Common.Models.ServiceSearch;
using RedPet.Database.Entities;
using System.Collections.Generic;
using System.Linq;
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
        public override async Task<Service> GetAsync(int id)
        {
            return await DbSet
                .Include(x => x.ServicePetSizes).ThenInclude(x => x.PetSize)
                .Include(x => x.ServiceSubServices).ThenInclude(x => x.ServiceSubType)
                .Include(x => x.ServiceFrecuencies).ThenInclude(x => x.Frecuency)
                .Include(x => x.Provider)
                .Include(x => x.ServiceType)
                .Include(x => x.WeekDays)
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<IEnumerable<Service>> Search(ServiceSearchModel parameters)
        {
            var query = DbSet
                .Include(x => x.ServicePetSizes).ThenInclude(x => x.PetSize)
                .Include(x => x.ServiceSubServices).ThenInclude(x => x.ServiceSubType)
                .Include(x => x.ServiceFrecuencies).ThenInclude(x => x.Frecuency)
                .Include(x => x.Provider)
                .Include(x => x.ServiceType)
                .Include(x => x.WeekDays)
                .Where(x => x.ServiceTypeId == parameters.ServiceTypeId)
                .Where(x => x.ServicePetSizes.Any(s => s.Id == parameters.PetSizeId))
                .Skip(parameters.PageNo * parameters.PageSize)
                .Take(parameters.PageSize);
                
            if(parameters.Monday || parameters.Tuesday || parameters.Wednesday || parameters.Thursday || parameters.Friday || parameters.Saturday || parameters.Sunday)
            {
                query = query.GroupBy(x=>x.ProviderId).Where(x=>x.Any(p=>p.))
            }
        }
    }

    public interface IServiceRepository : IRepository<Service>
    {
    }
}
