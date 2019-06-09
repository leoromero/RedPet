
using System;
using System.Collections.Generic;
using System.Text;
using RedPet.Database.Entities;

namespace RedPet.Database.Repositories
{
    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        public StateRepository(RedPetContext context) : base(context)
        {
        }
    }

    public interface IStateRepository : IRepository<State>
    {
    }
}
