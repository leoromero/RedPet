
using System;
using System.Collections.Generic;
using System.Text;
using RedPet.Database.Entities;

namespace RedPet.Database.Repositories
{
    public class AudienceRepository : GenericRepository<Audience>, IAudienceRepository
    {
        public AudienceRepository(RedPetContext context) : base(context)
        {
        }
    }

    public interface IAudienceRepository : IRepository<Audience>
    {
    }
}
