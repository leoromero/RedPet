using RedPet.Database.Entities;

namespace RedPet.Database.Repositories
{
    public class PetRepository : GenericRepository<Pet>, IPetRepository
    {
        public PetRepository(RedPetContext context) : base(context)
        {
        }
    }

    public interface IPetRepository : IRepository<Pet>
    {
    }
}
