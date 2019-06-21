
using System;
using System.Collections.Generic;
using System.Text;
using RedPet.Database.Entities;

namespace RedPet.Database.Repositories
{
    public class IdentificationTypeRepository : GenericRepository<IdentificationType>, IIdentificationTypeRepository
    {
        public IdentificationTypeRepository(RedPetContext context) : base(context)
        {
        }
    }

    public interface IIdentificationTypeRepository : IRepository<IdentificationType>
    {
    }
}
