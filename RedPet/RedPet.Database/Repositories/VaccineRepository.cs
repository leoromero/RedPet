
using System;
using System.Collections.Generic;
using System.Text;
using RedPet.Database.Entities;

namespace RedPet.Database.Repositories
{
    public class VaccineRepository : GenericRepository<Vaccine>, IVaccineRepository
    {
        public VaccineRepository(RedPetContext context) : base(context)
        {
        }
    }

    public interface IVaccineRepository : IRepository<Vaccine>
    {
    }
}
