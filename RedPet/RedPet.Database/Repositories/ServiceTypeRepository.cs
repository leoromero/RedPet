
using System;
using System.Collections.Generic;
using System.Text;
using RedPet.Database.Entities;

namespace RedPet.Database.Repositories
{
    public class ServiceTypeRepository : GenericRepository<ServiceType>, IServiceTypeRepository
    {
        public ServiceTypeRepository(RedPetContext context) : base(context)
        {
        }
    }

    public interface IServiceTypeRepository : IRepository<ServiceType>
    {
    }
}
