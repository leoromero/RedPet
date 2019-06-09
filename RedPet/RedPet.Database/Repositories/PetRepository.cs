using Microsoft.EntityFrameworkCore;
using RedPet.Database.Entities;
using System.Threading.Tasks;

namespace RedPet.Database.Repositories
{
    public class PetRepository : GenericRepository<Pet>, IPetRepository
    {
        public PetRepository(RedPetContext context) : base(context)
        {
        }

        public override async Task<Pet> GetAsync(int id)
        {
            return await DbSet.Include(x => x.Breed).Include(x => x.PetSize).Include(x => x.WeightRange).Include(x => x.Vet).FirstOrDefaultAsync(x => x.Id == id);
        }
    }

    public interface IPetRepository : IRepository<Pet>
    {
    }
}
