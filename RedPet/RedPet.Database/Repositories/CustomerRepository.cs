using Microsoft.EntityFrameworkCore;
using RedPet.Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedPet.Database.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(RedPetContext context) : base(context)
        {
        }

        public override async Task<Customer> GetAsync(int id)
        {
            return await DbSet.Include(x => x.User)
                              .Include(x => x.Pets).ThenInclude(x => x.Breed)
                              .Include(x => x.Pets).ThenInclude(x=>x.PetSize)
                              .Include(x => x.Pets).ThenInclude(x=>x.HairType)
                              .Include(x => x.Pets).ThenInclude(x=>x.WeightRange)
                              .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Customer> GetByEmailAsync(string email)
        {
            return DbSet.Include(x => x.User)
                              .Include(x => x.Pets).ThenInclude(x => x.Breed)
                              .Include(x => x.Pets).ThenInclude(x => x.PetSize)
                              .Include(x => x.Pets).ThenInclude(x => x.HairType)
                              .Include(x => x.Pets).ThenInclude(x => x.WeightRange)
                              .SingleOrDefaultAsync(x => x.User.Email == email);
        }

        public async Task<IEnumerable<Pet>> GetPetsAsync(int userId)
        {
            var customer = await DbSet.Include(x => x.Pets).FirstOrDefaultAsync(x => x.Id == userId);
            return customer.Pets.ToList();
        }
    }

    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetByEmailAsync(string email);
        Task<IEnumerable<Pet>> GetPetsAsync(int userId);
    }
}
