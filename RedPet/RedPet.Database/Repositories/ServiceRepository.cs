
using System;
using System.Collections.Generic;
using System.Text;
using RedPet.Database.Entities;

namespace RedPet.Database.Repositories
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(RedPetContext context) : base(context)
        {
        }
    }

    public interface IServiceRepository : IRepository<Service>
    {
    }
}
