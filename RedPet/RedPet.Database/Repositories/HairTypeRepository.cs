
using System;
using System.Collections.Generic;
using System.Text;
using RedPet.Database.Entities;

namespace RedPet.Database.Repositories
{
    public class HairTypeRepository : GenericRepository<HairType>, IHairTypeRepository
    {
        public HairTypeRepository(RedPetContext context) : base(context)
        {
        }
    }

    public interface IHairTypeRepository : IRepository<HairType>
    {
    }
}
