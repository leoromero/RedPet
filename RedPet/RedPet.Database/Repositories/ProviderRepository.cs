using Microsoft.EntityFrameworkCore;
using RedPet.Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedPet.Database.Repositories
{
    public class ProviderRepository : GenericRepository<Provider>, IProviderRepository
    {
        public ProviderRepository(RedPetContext context) : base(context)
        {
        }

        public override async Task<Provider> GetAsync(int id)
        {
            return await DbSet.Include(x => x.User)
                              .Include(x => x.Services)                             
                              .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Provider> GetByEmailAsync(string email)
        {
            return DbSet.Include(x => x.User)
                              .Include(x => x.Services)
                              .SingleOrDefaultAsync(x => x.User.Email == email);
        }

        public async Task<IEnumerable<Service>> GetServicesAsync(int userId)
        {
            var customer = await DbSet
                .Include(x => x.Services)
                .FirstOrDefaultAsync(x => x.User.Id == userId);
            return customer.Services.ToList();
        }
    }

    public interface IProviderRepository : IRepository<Provider>
    {
        Task<Provider> GetByEmailAsync(string email);
        Task<IEnumerable<Service>> GetServicesAsync(int userId);
    }
}
