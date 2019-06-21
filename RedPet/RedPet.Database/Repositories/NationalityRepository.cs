
using System;
using System.Collections.Generic;
using System.Text;
using RedPet.Database.Entities;

namespace RedPet.Database.Repositories
{
    public class NationalityRepository : GenericRepository<Nationality>, INationalityRepository
    {
        public NationalityRepository(RedPetContext context) : base(context)
        {
        }
    }

    public interface INationalityRepository : IRepository<Nationality>
    {
    }
}
