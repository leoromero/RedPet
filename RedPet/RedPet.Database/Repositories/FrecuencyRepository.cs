using RedPet.Database.Entities;

namespace RedPet.Database.Repositories
{
    public class FrecuencyRepository : GenericRepository<Frecuency>, IFrecuencyRepository
    {
        public FrecuencyRepository(RedPetContext context) : base(context)
        {
        }
    }

    public interface IFrecuencyRepository : IRepository<Frecuency>
    {
    }
}
