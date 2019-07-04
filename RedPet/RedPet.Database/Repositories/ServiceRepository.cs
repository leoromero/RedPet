
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedPet.Database.Entities;

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
                .Include(x => x.ServicePetSizes)
                .Include(x => x.ServiceSubServices)
                .Include(x=>x.Provider)
                .Include(x=>x.ServiceType)
                .Include(x=>x.WeekDays)
                .ToListAsync();
        }
    }

    public interface IServiceRepository : IRepository<Service>
    {
    }
}
