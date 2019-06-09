
using System;
using System.Collections.Generic;
using System.Text;
using RedPet.Database.Entities;

namespace RedPet.Database.Repositories
{
    public class BreedRepository : GenericRepository<Breed>, IBreedRepository
    {
        public BreedRepository(RedPetContext context) : base(context)
        {
        }
    }

    public interface IBreedRepository : IRepository<Breed>
    {
    }
}
