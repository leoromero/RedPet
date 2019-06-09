
using System;
using System.Collections.Generic;
using System.Text;
using RedPet.Database.Entities;

namespace RedPet.Database.Repositories
{
    public class PetSizeRepository : GenericRepository<PetSize>, IPetSizeRepository
    {
        public PetSizeRepository(RedPetContext context) : base(context)
        {
        }
    }

    public interface IPetSizeRepository : IRepository<PetSize>
    {
    }
}
